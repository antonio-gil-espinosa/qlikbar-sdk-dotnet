using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Agile;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using QlikBar.SDK.DotNet40.Infrastructure.Repositories;
using QlikBar.SDK.DotNet40.Services.DTOs;
using QlikBar.SDK.DTOs;
using Order = QlikBar.SDK.DotNet40.Domain.Model.Order;

namespace QlikBar.SDK.DotNet40.Services
{
    public class Listener
    {
#if LOCAL && DEBUG
        public const string API = "http://localhost:1111";
        public const string BACKOFFICE = "http://localhost:2442";
        public const string FRONTEND = "http://localhost:54745";
#elif DEBUG && !LOCAL
        public const string API = "http://test.api.qlikbar.com";
        public const string BACKOFFICE = "http://test.backoffice.qlikbar.com";
        public const string FRONTEND = "http://test.qlikbar.com";
#elif !DEBUG && !LOCAL
        public const string API = "http://api.qlikbar.com";
        public const string BACKOFFICE = "http://backoffice.qlikbar.com";
        public const string FRONTEND = "http://qlikbar.com";
#endif

        private readonly string _username;
        private readonly string _password;
        private readonly string _apiKey;
        private readonly int _localId;
         
        public Listener(string username, string password,string apiKey, int localId)
        {
            _repositoryFactory = new RepositoryFactory(localId,apiKey);

            
            _username = username;
            _password = password;
            _apiKey = apiKey;
            _localId = localId;

            //tableCache = new Cache<IEnumerable<Domain.Model.Table>>(_repositoryFactory.GetTableRepository().ToArray,TimeSpan.FromMinutes(5));
        }

        private bool _exiting;
        private HubConnection hubConnection;

        public event Action Closed { add { hubConnection.Closed += value; }
            remove { hubConnection.Closed -= value; } }

        public event Action ConnectionSlow { add { hubConnection.ConnectionSlow += value; }
            remove { hubConnection.ConnectionSlow -= value; } }

        public event Action<Exception> Error { add { hubConnection.Error += value; }
            remove { hubConnection.Error -= value; } }

        /*public event Action Reconnecting { add { hubConnection.Reconnecting += value; }
            remove { hubConnection.Reconnecting -= value; } }

        public event Action Reconnected { add { hubConnection.Reconnected += value; }
            remove { hubConnection.Reconnected -= value; } }

        public event Action<string> Received { add { hubConnection.Received += value; }
            remove { hubConnection.Received -= value; } }

        public event Action<StateChange> StateChanged { add { hubConnection.StateChanged += value; }
            remove { hubConnection.StateChanged -= value; } }*/

        public event Action Connected;

        private bool _joined;
        private static IHubProxy ordersHub;
        private static Task theTask;
        private readonly RepositoryFactory _repositoryFactory;

        public void Start()
        {
            theTask = CreateSignalRTasks();
        }

        public void Stop()
        {
            _exiting = true;
            theTask.Wait();
        }

        public event Action<CheckInDTO> OnCheckIn;
        public event Action<OrderCollectionDTO> OnNewOrder;
        public event Action<CheckInDTO> OnAskedForBill;
        public event Action<CheckInDTO> OnSummonedServer;


        private void RaiseOnConnected()
        {
            if (Connected == null)
                return;


            Connected();
        }
     

        private void RaiseOnCheckIn(CheckInDTO checkIn)
        {
            if (OnCheckIn == null)
                return;


            OnCheckIn(checkIn);
        }

        private void RaiseOnNewOrder(OrderCollectionDTO ordersCollectionDto)
        {
            if (OnNewOrder == null)
                return;


            OnNewOrder(ordersCollectionDto);
        }

        private void RaiseOnAskedForBill(CheckInDTO checkIn)
        {
            if (OnAskedForBill == null)
                return;

           
            OnAskedForBill(checkIn);
        }

        private void RaiseOnSummonedServer(CheckInDTO checkIn)
        {
            if (OnSummonedServer == null)
                return;

        
            OnSummonedServer(checkIn);
        }


        private void Join()
        {
            Task task = ordersHub.Invoke("Join", _username, _password);
            task.Wait();
            _joined = true;
        }

        private void Initialize()
        {
            if (hubConnection != null)
                hubConnection.Stop(TimeSpan.FromSeconds(5));

            hubConnection = new HubConnection(API);
          
            ordersHub = hubConnection.CreateHubProxy("OrdersHub");

            ordersHub.On<CheckInDTO>("NewCheckIn", RaiseOnCheckIn);
            ordersHub.On<CheckInDTO>("AskedForBill", RaiseOnAskedForBill);
            ordersHub.On<CheckInDTO>("SummonedServer", RaiseOnSummonedServer);
            ordersHub.On<OrderCollectionDTO>("NewOrders", RaiseOnNewOrder);

            hubConnection.Start()
                         .Wait();
        }

        private static void Ping()
        {
            Task task = ordersHub.Invoke("Ping");
            task.Wait();
        }


        private Task CreateSignalRTasks()
        {
            return Task.Factory.StartNew(() =>
                                         {
                                            
                                             while (!_exiting)
                                             {
                                                 try
                                                 {
                                                     if (hubConnection == null ||
                                                         hubConnection.State == ConnectionState.Disconnected)
                                                     {
                                                         Initialize();
                                                     }

                                                     if (!_joined && hubConnection.State == ConnectionState.Connected)
                                                     {
                                                         Join();
                                                        RaiseOnConnected();
                                                     }

                                                     if (hubConnection.State == ConnectionState.Connected && _joined)
                                                     {
                                                         Ping();
                                                     }
                                                 }
                                                 catch
                                                 {
                                                     _joined = false;
                                                     try
                                                     {
                                                         hubConnection.Stop(TimeSpan.FromSeconds(5));
                                                     }
                                                     catch
                                                     {
                                                         
                                                     }


                                                 }

                                                 Thread.Sleep(10000);
                                             }
                                             try
                                             {
                                                 hubConnection.Stop();
                                             }
                                             catch {}

                                             _joined = false;
                                         });
        }
    }
}
