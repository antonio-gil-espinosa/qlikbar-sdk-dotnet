using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using QlikBar.SDK.DTOs;

namespace QlikBar.SDK.Results
{
    public class CheckInResult
    {
        [JsonProperty("id")]
        public int CheckInId { get; set; }

        [JsonProperty("earnedPoints")]
        public int EarnedPoints { get; set; }

        [JsonProperty("totalPoints")]
        public int TotalPoints { get; set; }

        [JsonProperty("checkIns")]
        public int CheckIns { get; set; }

        [JsonProperty("local")]
        public string LocalName { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("welcome")]
        public string WelcomeMessage { get; set; }

        [JsonProperty("table")]
        public Table Table { get; set; }
    }
}
