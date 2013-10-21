using System.Xml.Serialization;
using Newtonsoft.Json;

namespace QlikBar.SDK.DotNet40.Services.DTOs
{
    [XmlRoot("table")]
    public class TableDTO
    {
        [XmlElement("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [XmlElement("remote-id")]
        [JsonProperty("remoteId")]
        public string RemoteId { get; set; }
    }
}
