using System.Xml.Serialization;
using Newtonsoft.Json;

namespace QlikBar.SDK.DotNet40.Services.DTOs
{
    [XmlRoot("article")]
    public class ArticleDTO
    {
        [XmlElement("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [XmlElement("remote-id")]
        [JsonProperty("remoteId")]
        public string RemoteId { get; set; }
    }
}
