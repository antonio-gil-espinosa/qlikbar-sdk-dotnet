using System.Linq;
using System.Threading;
using Agile;
using Agile.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QlikBar.SDK.DotNet40;
using QlikBar.SDK.DotNet40.Domain.Model;
using QlikBar.SDK.DotNet40.Infrastructure;
using QlikBar.SDK.DotNet40.Infrastructure.Repositories;
using QlikBar.SDK.DotNet40.Services;
using QlikBar.SDK.DotNet40.Services.DTOs;
using QlikBar.SDK.Results;
using QlikBar.SDK.DTOs;
using System.Collections.Generic;

using Article = QlikBar.SDK.DotNet40.Domain.Model.Article;
using Category = QlikBar.SDK.DTOs.Category;
using CheckIn = QlikBar.SDK.DTOs.CheckIn;
using IdentityMap = QlikBar.SDK.DotNet40.Infrastructure.IdentityMap;
using Order = QlikBar.SDK.DTOs.Order;
using OrderPart = QlikBar.SDK.DTOs.OrderPart;
using Table = QlikBar.SDK.DTOs.Table;

namespace QlikBar.SDK.Tests
{


    /// <summary>
    ///Se trata de una clase de prueba para LocalWebServicesTest y se pretende que
    ///contenga todas las pruebas unitarias LocalWebServicesTest.
    ///</summary>
    [TestClass]
    public class LocalWebServicesTest
    {
        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba

        private ClientWebServices cws;
        private LocalWebServices target;
        private RepositoryFactory rf;

        [TestInitialize]
        public void MyTestInitialize()
        {
            string apiKey = "486ce85808d184609445840ebc2e4f98";
            int localId = 1634;
            target = new LocalWebServices(localId, apiKey);
            rf = new RepositoryFactory(localId, apiKey);
            cws = new ClientWebServices(1235,"Li8ujko97!");


            /*var xxx = rf.GetCategoryRepository()
                        .ToList();

            var xx = xxx.ToArray();*/
            /* Listener listener = new Listener("test@qlikbar.com", "soypepa",apiKey,localId);
            listener.OnAskedForBill += new Action<CheckInDTO>(listener_OnAskedForBill);
            listener.OnCheckIn += new Action<CheckInDTO>(listener_OnCheckIn);
            listener.OnNewOrder += new Action<OrderCollectionDTO>(listener_OnNewOrder);
            listener.OnSummonedServer += new Action<CheckInDTO>(listener_OnSummonedServer);
            listener.Start();

            while(true)
                Thread.Sleep(100);*/

        }

        private static void listener_OnSummonedServer(CheckInDTO checkInDto)
        {
           
        }

        private static void listener_OnNewOrder(OrderCollectionDTO orderCollectionDto)
        {
            
        }

        private static void listener_OnCheckIn(CheckInDTO checkInDto)
        {
            
        }

        private static void listener_OnAskedForBill(CheckInDTO checkInDto)
        {
            
        }




        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod]
        public void ClientRegisterTest()
        {
            string email = Faker.Internet.Email();
            string password = Randomizer.GetRandomWord();
            string firstName = Faker.Name.First();
            string lastName = Faker.Name.Last();
            string paseBerde = Randomizer.GetRandomWord();

            target.RegisterClient(email, password, firstName, lastName, paseBerde);


            Client client = target.GetClients().Data
                                  .SingleOrDefault(
                                                   x =>
                                                   String.Equals(firstName, x.FirstName, StringComparison.InvariantCultureIgnoreCase) &&
                                                   String.Equals(lastName, x.LastName, StringComparison.InvariantCultureIgnoreCase) &&
                                                   String.Equals(paseBerde, x.PaseBerde, StringComparison.InvariantCultureIgnoreCase));


            Assert.IsNotNull(client);
        }

        /// <summary>
        ///Una prueba de AddPoints
        ///</summary>
        [TestMethod]
        public void AddPointsTest()
        {
            IEnumerable<Client> clients = target.GetClients().Data
                                                   .Where(x => x.Points >= 0)
                                                   .ToArray();

            for (int i = 0; i < 10; i++)
            {
                

                Client client = clients.GetRandomElement();

                int oldPoints = client.Points;
                int change = Randomizer.GetIntBetween(1, 400);
                string randomWord = Faker.Lorem.Sentence(3);

                Response<AddPointResult, string> response = target.AddPoints(client.Id, change, randomWord);
                int expected = oldPoints + change;

                Assert.AreEqual(0, response.Code);
                Assert.AreEqual(expected, response.Data.Points);

                clients = target.GetClients()
                                .Data.Where(x => x.Points >= 0)
                                .ToArray();

                client = clients.Single(x => x.Id == client.Id);
                Assert.AreEqual(expected, client.Points);
      
            }
        }

        [TestMethod]
        public void GetClientFailTest()
        {
            Response<Client> response = target.GetClient(98123);
            Assert.AreEqual(1,response
                                  .Code);
            Assert.IsNull(response.Data);
        }


        [TestMethod]
        public void SetOrdersTest()
        {
            Category[] categories = target.GetMenu();
            Table[] tables = target.GetTables();

            Table table = tables.Where(x => x.Enabled && !x.CheckIns.Any())
                                     .GetRandomElement();

            cws.TableCheckIn(table.Id);

            GetValue(categories, table);
            GetValue(categories, table);
        }

        private void GetValue(Category[] categories, Table table)
        {
            Table[] tables;
            IEnumerable<SetOrderDTO> setOrderDtos = categories.Transverse(x => x.Subcategories)
                                                              .SelectMany(x => x.Articles)
                                                              .Where(x => x.Visibility == 1)
                                                              .Select(
                                                                      x =>
                                                                      new SetOrderDTO()
                                                                      {
                                                                          Price = x.Price,
                                                                          ArticleId = x.Id,
                                                                          Quantity = Randomizer.GetIntBetween(1, 4),
                                                                          Status = Randomizer.GetIntBetween(1, 4),
                                                                          Parts =
                                                                              x.Parts.Select(
                                                                                             y =>
                                                                                             new SetOrderPartDTO()
                                                                                             {
                                                                                                 Article =
                                                                                                     y
                                                                                                     .Candidates
                                                                                                     .GetRandomElement
                                                                                                     ()
                                                                                                     .Article
                                                                                             })
                                                                               .ToArray()
                                                                      })
                                                              .ToArray();
            target.SetOrders(table.Id, setOrderDtos);

            tables = target.GetTables();
            IEnumerable<Order> orders = tables.Single(x => x.Id == table.Id)
                                              .CheckIns.SelectMany(x => x.Orders);
            Assert.AreEqual(setOrderDtos.Count(), orders.Count());
            foreach (Order order in orders)
            {
                SetOrderDTO soDto = setOrderDtos.Single(x => x.ArticleId == order.Article);
                Assert.AreEqual(soDto.Price, order.Price);
                Assert.AreEqual(soDto.Quantity, order.Quantity);
                Assert.AreEqual(soDto.Status, order.Status);
                foreach (OrderPart part in order.Parts)
                {
                    int indexOfPart = order.Parts.IndexOf(part);
                    SetOrderPartDTO setOrderPartDto = soDto.Parts.Single(x => x.Article == part.Article);
                    int indexOfDTOPart = soDto.Parts.IndexOf(setOrderPartDto);
                    Assert.IsTrue(indexOfPart == indexOfDTOPart);
                }
            }
        }

        [TestMethod]
        public void GetClientByPaseBerdeFailTest()
        {
            Response<Client> clientByPaseBerde = target.GetClientByPaseBerde("kjsahmdkashnfjsdhnf");
            Assert.AreEqual(1, clientByPaseBerde
                              .Code);
            Assert.IsNull(clientByPaseBerde.Data);
        }

        [TestMethod]
        public void GetClientTest()
        {
            int id = target.GetClients()
                           .Data.GetRandomElement()
                           .Id;

            Response<Client> response = target.GetClient(id);
            Client client = response.Data;

            Assert.AreEqual(0,response.Code);
            Assert.IsNotNull(client);
        }


        [TestMethod]
        public void GetClientByPaseBerdeTest()
        {
            string paseBerde = target.GetClients()
                                     .Data.Where(x => !string.IsNullOrWhiteSpace(x.PaseBerde)).GetRandomElement()
                                     .PaseBerde;
            Response<Client> response = target.GetClientByPaseBerde(paseBerde);
            Client client = response
                              .Data;

            Assert.AreEqual(0, response.Code);
            Assert.IsNotNull(client);
        }

        /// <summary>
        ///Una prueba de CloseTable
        ///</summary>
        [TestMethod]
        public void OpenAndCloseTablesTest()
        {
            Table[] tables = target.GetTables().ToArray();
            foreach (Table table in tables.Where(x => x.CheckIns.Any()))
                target.CloseTable(table.Id);

            tables = target.GetTables().ToArray();
            Assert.AreEqual(0, tables.Count(x => x.CheckIns.Any()));
            foreach (Table table in tables.Where(x => !x.CheckIns.Any()))
                Assert.AreEqual(0, target.OpenTable(table.Id).Code);

            tables = target.GetTables().ToArray();
            Assert.AreEqual(tables.Count(), tables.Count(x => x.CheckIns.Any()));
            foreach (Table table in tables.Where(x => x.CheckIns.Any()))
                Assert.AreEqual(0, target.CloseTable(table.Id).Code);

          

        }

        /// <summary>
        ///Una prueba de ConsumePoints
        ///</summary>
        [TestMethod]
        public void ConsumePointsTest()
        {
            IEnumerable<Client> clients = target.GetClients().Data.ToArray();
            for (int i = 0; i < 10; i++)
            {
                Client client = clients.GetRandomElement();

                int oldPoints = client.Points;
                if (oldPoints <= 0)
                {
                    target.AddPoints(client.Id, 1200, "xx");
                    clients = target.GetClients().Data.ToArray();
                    client = clients.Single(x => x.Id == client.Id);
                    oldPoints = client.Points;
                }

                int change = Randomizer.GetIntBetween(1, oldPoints);

                Response<AddPointResult, string> response = target.ConsumePoints(client.Id, change, Faker.Lorem.Sentence(3));

                int expected = oldPoints - change;

                Assert.AreEqual(expected, response.Data.Points);
                Assert.AreEqual(0, response.Code);
                clients = target.GetClients().Data.ToArray();
                client = clients.Single(x => x.Id == client.Id);
                Assert.AreEqual(expected, client.Points);



                response = target.ConsumePoints(client.Id, (oldPoints + 10)*2, Randomizer.GetRandomWord(8));

                Assert.AreEqual(response.Code, 1);
                Assert.AreEqual(expected, response.Data.Points);
                Assert.AreNotEqual(0, response.Errors.Length);
                clients = target.GetClients().Data.ToArray();
                client = clients.Single(x => x.Id == client.Id);
                Assert.AreEqual(expected, client.Points);
              
            }




        }

        /// <summary>
        ///Una prueba de CreateArticle
        ///</summary>
        [TestMethod]
        public void CreateAndDeleteMenuTest()
        {



            IEnumerable<Category> categories = target.GetMenu()
                                                     .ToArray();

            IEnumerable<Category> transverse = categories.Transverse(x => x.Subcategories)
                                                         .ToArray();

            while (transverse.Any())
            {
                foreach (Category category in transverse.Where(x => !x.Subcategories.Any()))
                {
                    foreach (DTOs.Article article in category.Articles)
                        target.DeleteArticle(article.Id);

                    target.DeleteCategory(category.Id);
                }
                categories = target.GetMenu().ToArray();
                transverse = categories.Transverse(x => x.Subcategories)
                                                         .ToArray();

            }


            CreateCategories(Randomizer.GetIntBetween(3, 12), null);



        }

        private void CreateCategories(int quantity, int? parent)
        {
            for (int i = 0; i < quantity; i++)
            {
                string name = string.Join(" ",Faker.Lorem.Words(2)).ToFirstCharUpper();
                string description = Randomizer.GetBool() ? Faker.Lorem.Sentence(15) : null;
                string image = null;
                bool visible = Randomizer.GetBool();
                string remoteId = Randomizer.GetRandomWord(8);
                Response<CreateCategoryResult> response = target.CreateCategory(name, description, image, visible, remoteId, parent);
                IEnumerable<Category> categories = target.GetMenu()
                                                         .Transverse(x => x.Subcategories)
                                                         .ToArray();
                Category category =
                    categories.SingleOrDefault(
                                               x =>
                                               x.Id == response.Data.Id && x.Name == name && x.Visible == visible && x.RemoteId == remoteId && x.Parent == parent);
                Assert.IsNotNull(category);

                if (Randomizer.GetIntBetween(1, 100) > 88)
                    CreateCategories(Randomizer.GetIntBetween(2, 5), response.Data.Id);
                else
                    CreateArticles(response.Data.Id);


            }
        }

        private void CreateArticles(int category)
        {
            int intBetween = Randomizer.GetIntBetween(2, 4);
            for (int i = 0; i < intBetween; i++)
            {
                string name = string.Join(" ", Faker.Lorem.Words(2)).ToFirstCharUpper();
                string description = Randomizer.GetBool() ? Faker.Lorem.Sentence(15) : null;
                string image = null;
                Decimal price = Randomizer.GetDecimalBetween(1, 30);

                int visibility = Randomizer.GetIntBetween(0, 2);
                string remoteId = Randomizer.GetRandomWord(10);
                Decimal discount = Randomizer.GetBool() ? 0 : Randomizer.GetDecimalBetween(0, (double)price);
                bool allowHomeOrders = Randomizer.GetBool();

                Response<CreateArticleResult> result;
                IEnumerable<ComboPart> generateComboLists=null;
              
                IRepository<Article> articleRepository = rf.GetArticleRepository();
                bool createCombo = Randomizer.GetBool() && articleRepository.Count > 3;
                if (createCombo)
                {
                    generateComboLists = GenerateComboLists();
                    result = target.CreateArticle(name,
                                                  description,
                                                  image,
                                                  price,
                                                  category,
                                                  visibility,
                                                  remoteId,
                                                  discount,
                                                  allowHomeOrders, generateComboLists);
                }
                else
                {
                    result = target.CreateArticle(name, description, image, price, category, visibility, remoteId, discount, allowHomeOrders);
                }

                DTOs.Article article = target.GetMenu()
                                        .Transverse(x => x.Subcategories)
                                        .SelectMany(x => x.Articles)
                                        .SingleOrDefault(
                                                         x =>
                                                         x.Id == result.Data.Id && x.Name == name &&
                                                         Math.Abs(x.Price - price) < (decimal) 0.02 && x.Visibility == visibility &&
                                                         x.RemoteId == remoteId && x.Parent == category);

                Assert.IsNotNull(article);
                if (createCombo)
                {
                    foreach (ComboPart comboList in generateComboLists)
                    {
                        ComboPart gComboList = article.Parts.SingleOrDefault(x => x.Name == comboList.Name);
                        Assert.IsNotNull(gComboList);
                        foreach (Candidate gCandidate in
                            comboList.Candidates.Select(
                                                        c =>
                                                        gComboList.Candidates.SingleOrDefault(
                                                                                              x =>
                                                                                              x.Article == c.Article &&  Math.Abs(x.Price - c.Price) < 0.01m ))
                            )
                        {
                            Assert.IsNotNull(gCandidate);
                        }

                    }
                }
            }
        }

        private IEnumerable<ComboPart> GenerateComboLists()
        {
            IRepository<Article> articleRepository = rf.GetArticleRepository();
            IEnumerable<Article> articles = articleRepository.Where(x => x.Visibility == 0 || x.Visibility == 1)
                                                             .ToArray();

            int i = Randomizer.GetRandomElement(1, 3);
            return i.Times(() => new ComboPart()
                                 {
                                     Candidates = Randomizer.GetRandomElement(2, 5)
                                                            .Times(() => articles.GetRandomElement())
                                                            .Distinct()
                                                            .Select(GetCandidate)
                                                            .ToArray(),
                                     Name = string.Join(" ",Faker.Lorem.Words(2)).ToFirstCharUpper()
                                 });

        }

        private static Candidate GetCandidate(Article x)
        {
            return new Candidate() {Article = x.Id, Price = Randomizer.GetBool() ? 0 : Randomizer.GetDecimalBetween(0, 1)};
        }

        /// <summary>
        ///Una prueba de CreateTable
        ///</summary>
        [TestMethod]
        public void CreateAndDeleteTablesTest()
        {
            IEnumerable<Table> tables = target.GetTables().ToArray();
            for (int i = 0; i < tables.Count(); i++)
            {
                target.DeleteTable(tables.ElementAt(i).Id);
                Assert.AreEqual(tables.Count() - i - 1,
                              target.GetTables().Count());
            }

            try
            {
                target.DeleteTable(29);
                Assert.Fail("I can delete a table not belonging to my local.");
            }
            catch (Exception)
            {
                
            }
            

            for (int i = 0; i < 8; i++)
            {
                bool enabled = Randomizer.GetBool();
                string name = "Mesa "+(i+1)+" ("+Randomizer.GetRandomWord(4)+")";
                string remoteId = Randomizer.GetRandomWord(5);
                target.CreateTable(enabled,name,remoteId);

                Table table = target.GetTables().SingleOrDefault(x => x.Name == name && x.RemoteId == remoteId && x.Enabled == enabled);

                Assert.IsNotNull(table);

            }


        }

       

        /// <summary>
        ///Una prueba de EditArticle
        ///</summary>
        [TestMethod]
        public void EditArticleTest()
        {
            DTOs.Article[] articles = target.GetMenu()
                                                  .Transverse(x => x.Subcategories)
                                                  .SelectMany(x => x.Articles)
                                                  .ToArray();
                                  
            for (int i = 0; i < 10; i++)
            {
                DTOs.Article article = articles.GetRandomElement();

                string name = string.Join(" ", Faker.Lorem.Words(2)).ToFirstCharUpper();
                string description = Randomizer.GetBool() ? Faker.Lorem.Sentence(15) : null;
                string image = null;
                Decimal price = Randomizer.GetDecimalBetween(1, 30);

                int visibility = Randomizer.GetIntBetween(0, 2);
                string remoteId = Randomizer.GetRandomWord(10);
                Decimal discount = Randomizer.GetBool() ? 0 : Randomizer.GetDecimalBetween(0, (double)price);
                bool allowHomeOrders = Randomizer.GetBool();

                target.EditArticle(article.Id,name,description,image,price,visibility,remoteId,discount,allowHomeOrders);

                article = target.GetMenu()
                                        .Transverse(x => x.Subcategories)
                                        .SelectMany(x => x.Articles)
                                        .SingleOrDefault(
                                                         x =>
                                                         x.Id == article.Id && x.Name == name &&
                                                         Math.Abs(x.Price -  price) < (decimal) 0.02 && x.Visibility == visibility &&
                                                         x.RemoteId == remoteId);

                Assert.IsNotNull(article);
            }
        }

        /// <summary>
        ///Una prueba de EditCategory
        ///</summary>
        [TestMethod]
        public void EditCategoryTest()
        {
            IEnumerable<Category> cats = target.GetMenu()
                                                   .Transverse(x => x.Subcategories)
                                                   .ToArray();

            for (int i = 3; i < cats.Count(); i++)
            {
                Category cat = cats.GetRandomElement();
                string name = string.Join(" ", Faker.Lorem.Words(2)).ToFirstCharUpper();
                string description = Randomizer.GetBool() ? Faker.Lorem.Sentence(15) : null;
                string image = null;
                bool visible = Randomizer.GetBool();
                string remoteId = Randomizer.GetRandomWord(8);

                target.EditCategory(cat.Id, name, description, image, visible, remoteId);

                cat = target.GetMenu()
                            .Transverse(x => x.Subcategories)
                            .SingleOrDefault(
                                             x =>
                                             x.Id == cat.Id && name == x.Name && x.Image == image && x.Visible == visible && x.RemoteId == remoteId);

                Assert.IsNotNull(cat);
            }
            
        }

        /// <summary>
        ///Una prueba de EditTable
        ///</summary>
        [TestMethod]
        public void EditTableTest()
        {
            IEnumerable<Table> tables = target.GetTables().ToArray();

            for (int i = 0; i < tables.Count() / 2; i++)
            {
                Table table = tables.GetRandomElement();
                bool enabled = Randomizer.GetBool();
                string name = "Mesa " + Randomizer.GetRandomWord(4) + " (" + Randomizer.GetRandomWord(4) + ")";
                string remoteId = Randomizer.GetRandomWord(5);
                target.EditTable(table.Id, enabled, name, remoteId);

                table = target.GetTables().SingleOrDefault(x => x.Id == table.Id && x.Name == name && x.RemoteId == remoteId && x.Enabled == enabled);

                Assert.IsNotNull(table);

            }

            try
            {
                target.EditTable(29, true, "xD", "xDD");
                Assert.Fail("I can delete a table not belonging to my local.");
            }
            catch (Exception)
            {

            }
        }


        /// <summary>
        ///Una prueba de SendPromotion
        ///</summary>
        [TestMethod]
        public void SendTargetedPromotionTest()
        {
          
            /*string title = Randomizer.GetRandomSentence(3);
            string content = Randomizer.GetRandomSentence(20);
            int[] targets = {1235};
        
            target.SendPromotion(title, content, targets);*/

        }

        /// <summary>
        ///Una prueba de SendPromotion
        ///</summary>
         [TestMethod]
         public void SendLivePromotionTest()
        {
       
             /*string title = Randomizer.GetRandomSentence(3);
             string content = Randomizer.GetRandomSentence(20);
  
             target.SendPromotion(title, content,true);*/
         }


    }
}
