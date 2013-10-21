using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QlikBar.SDK.Results
{
    public class CreateTableResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("qr")]
        public string Qr { get; set; }
    }
}
