using Newtonsoft.Json;

namespace QlikBar.SDK.Results
{
    public class AddPointResult
    {
        [JsonProperty("Points")]
        public int Points { get; set; }
    }
}
