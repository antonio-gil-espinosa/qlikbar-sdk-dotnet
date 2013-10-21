// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-17-2013
// ***********************************************************************
// <copyright file="AddPointResult.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace QlikBar.SDK.Results
{
    /// <summary>
    /// Class AddPointResult
    /// </summary>
    public class AddPointResult
    {
        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>The points.</value>
        [JsonProperty("Points")]
        public int Points { get; set; }
    }
}
