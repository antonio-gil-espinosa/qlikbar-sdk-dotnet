#region

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

#endregion

namespace QlikBar.SDK.DotNet40.Services.DTOs
{
    [XmlRoot("check-in")]
    public class CheckInDTO
    {
        [XmlElement("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [XmlElement("table")]
        [JsonProperty("table")]
        public TableDTO Table { get; set; }

        [XmlElement("datetime")]
        [JsonProperty("datetime")]
        public DateTime DateTime { get; set; }
    }
}