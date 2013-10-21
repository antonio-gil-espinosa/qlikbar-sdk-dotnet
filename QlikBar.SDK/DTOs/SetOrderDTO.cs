using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QlikBar.SDK.DTOs
{
    public class SetOrderDTO
    {
        [JsonProperty("article")]
        // ReSharper disable UnusedAutoPropertyAccessor.Local
        public int ArticleId { get; set; }

        [JsonProperty("checkIn")]
        public int CheckInId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("parts")]
        public SetOrderPartDTO[] Parts { get; set; }

        // ReSharper restore UnusedAutoPropertyAccessor.Local
    }

    public class SetOrderPartDTO
    {
        [JsonProperty("article")]
        public int Article { get; set; }
    }
}
