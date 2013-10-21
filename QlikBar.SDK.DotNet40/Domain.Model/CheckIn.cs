using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using QlikBar.SDK.DTOs;

namespace QlikBar.SDK.DotNet40.Domain.Model
{
    public class CheckIn : IEntity
    {
      
        public int Id { get; set; }

        public int Status { get; set; }

        public int Role { get; set; }

        public Client Owner { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public override string ToString() { return Id.ToString(); }
    }
}
