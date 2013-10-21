// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-17-2013
// ***********************************************************************
// <copyright file="Category.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QlikBar.SDK;

namespace QlikBar.SDK.DTOs
{

    /// <summary>
    /// Class Category
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the parent category id.
        /// </summary>
        /// <value>The parent.</value>
        [JsonProperty("parent")]
        public int? Parent { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the remote id.
        /// </summary>
        /// <value>The remote id.</value>
        [JsonProperty("remoteId")]
        public string RemoteId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the articles.
        /// </summary>
        /// <value>The articles.</value>
        [JsonProperty("articles")]
        public Article[] Articles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Category"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Category"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the subcategories.
        /// </summary>
        /// <value>The subcategories.</value>
        [JsonProperty("categories")]
        public Category[] Subcategories { get; set; }



        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() { return Id + " - " + Name; }

       
    }

}
