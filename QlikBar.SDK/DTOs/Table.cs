// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-17-2013
// ***********************************************************************
// <copyright file="Table.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using Newtonsoft.Json;

namespace QlikBar.SDK.DTOs
{

    /// <summary>
    /// Class Table
    /// </summary>
    public class Table
    {

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tariff.
        /// </summary>
        /// <value>The tariff.</value>
        [JsonProperty("tariff")]
        public int Tariff { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Table"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the remote id.
        /// </summary>
        /// <value>The remote id.</value>
        [JsonProperty("remoteId")]
        public string RemoteId { get; set; }

        /// <summary>
        /// Gets or sets the qr.
        /// </summary>
        /// <value>The qr.</value>
        [JsonProperty("qr")]
        public string Qr { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [asked for bill].
        /// </summary>
        /// <value><c>true</c> if [asked for bill]; otherwise, <c>false</c>.</value>
        [JsonProperty("askedForBill")]
        public bool AskedForBill { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [summoned server].
        /// </summary>
        /// <value><c>true</c> if [summoned server]; otherwise, <c>false</c>.</value>
        [JsonProperty("summonedServer")]
        public bool SummonedServer { get; set; }

        /// <summary>
        /// Gets or sets the check ins.
        /// </summary>
        /// <value>The check ins.</value>
        [JsonProperty("checkIns")]
        public CheckIn[] CheckIns { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() { return Id + " - " + Name; }
    }

}
