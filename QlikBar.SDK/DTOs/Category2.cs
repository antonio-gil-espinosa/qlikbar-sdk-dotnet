using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QlikBar.SDK.DTOs
{
    public class Category2 
    {
        public LocalWebServices WebServices { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("desc")]
        public string Name { get; set; }

        public override string ToString() { return Id + " - " + Name; }
    }
}
