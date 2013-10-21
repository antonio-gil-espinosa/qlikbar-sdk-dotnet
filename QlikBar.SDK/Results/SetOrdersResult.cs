using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QlikBar.SDK.Results
{
    public class SetOrdersResult
    {
        [JsonProperty("checkIn")]
        public int CheckInId { get; set; }

        [JsonProperty("orders")]
        public int [] OrdersId { get; set; }
    }
}
