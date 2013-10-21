// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-17-2013
// ***********************************************************************
// <copyright file="CreateTableResult.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QlikBar.SDK.Results
{
    /// <summary>
    /// Class CreateTableResult
    /// </summary>
    public class CreateTableResult
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the qr.
        /// </summary>
        /// <value>The qr.</value>
        [JsonProperty("qr")]
        public string Qr { get; set; }
    }
}
