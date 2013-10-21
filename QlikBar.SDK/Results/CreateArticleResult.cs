using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QlikBar.SDK.Results
{
    public class CreateArticleResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("img")]
        public string Image { get; set; }
    }
}
