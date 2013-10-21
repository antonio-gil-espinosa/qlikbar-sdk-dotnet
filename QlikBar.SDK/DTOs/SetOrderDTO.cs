// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-17-2013
// ***********************************************************************
// <copyright file="SetOrderDTO.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QlikBar.SDK.DTOs
{
    /// <summary>
    /// Class SetOrderDTO
    /// </summary>
    public class SetOrderDTO
    {
        /// <summary>
        /// Gets or sets the article id.
        /// </summary>
        /// <value>The article id.</value>
        [JsonProperty("article")]
        // ReSharper disable UnusedAutoPropertyAccessor.Local
        public int ArticleId { get; set; }

        /// <summary>
        /// Gets or sets the check in id.
        /// </summary>
        /// <value>The check in id.</value>
        [JsonProperty("checkIn")]
        public int CheckInId { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the parts.
        /// </summary>
        /// <value>The parts.</value>
        [JsonProperty("parts")]
        public SetOrderPartDTO[] Parts { get; set; }

        // ReSharper restore UnusedAutoPropertyAccessor.Local
    }

    /// <summary>
    /// Class SetOrderPartDTO
    /// </summary>
    public class SetOrderPartDTO
    {
        /// <summary>
        /// Gets or sets the article.
        /// </summary>
        /// <value>The article.</value>
        [JsonProperty("article")]
        public int Article { get; set; }
    }
}
