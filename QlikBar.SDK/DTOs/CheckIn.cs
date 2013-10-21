// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-17-2013
// ***********************************************************************
// <copyright file="CheckIn.cs" company="">
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
    /// Class CheckIn
    /// </summary>
    public class CheckIn
    {

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        [JsonProperty("role")]
        public int Role { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        [JsonProperty("owner")]
        public Client Owner { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        [JsonProperty("orders")]
        public Order[] Orders { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() { return Id.ToString(); }
    }

}
