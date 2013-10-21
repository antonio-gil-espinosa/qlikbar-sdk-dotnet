using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QlikBar.SDK.DotNet40.Domain.Model
{
    public class Table : IEntity
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public int Tariff { get; set; }


        public bool Enabled { get; set; }


        public string RemoteId { get; set; }

  
        public string Qr { get; set; }


        public bool AskedForBill { get; set; }


        public bool SummonedServer { get; set; }


        public CheckIn[] CheckIns { get; set; }
    }
}
