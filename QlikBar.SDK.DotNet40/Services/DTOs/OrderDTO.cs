using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace QlikBar.SDK.DotNet40.Services.DTOs
{
    [XmlRoot("order")]
    public class OrderDTO
    {
        [XmlElement("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [XmlElement("quantity")]
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [XmlElement("price")]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [XmlElement("tax-base")]
        [JsonProperty("taxBase")]
        public decimal TaxBase { get; set; }

        [XmlElement("datetime")]
        [JsonProperty("datetime")]
        public DateTime DateTime { get; set; }

        [XmlElement("article")]
        [JsonProperty("article")]
        public ArticleDTO Article { get; set; }

        [XmlElement("comments")]
        [JsonProperty("comments")]
        public string Comments { get; set; }

        [XmlArray("parts")]
        [XmlArrayItem("article")]
        [JsonProperty("parts")]
        public List<ArticleDTO> Parts { get; set; }
    }
}
