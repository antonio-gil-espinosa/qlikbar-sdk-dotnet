using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace QlikBar.SDK.DotNet40.Services.DTOs
{
    [XmlRoot("order-collection")]
    public class OrderCollectionDTO
    {
        [XmlElement("check-in")]
        [JsonProperty("checkIn")]
        public int CheckInId { get; set; }

        [XmlElement("table")]
        [JsonProperty("table")]
        public TableDTO Table { get; set; }

        [XmlArray("orders")]
        [XmlArrayItem("order")]
        [JsonProperty("orders")]
        public List<OrderDTO> Orders { get; set; }
    }
}