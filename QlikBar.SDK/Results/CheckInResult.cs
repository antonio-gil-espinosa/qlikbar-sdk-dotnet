// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-17-2013
// ***********************************************************************
// <copyright file="CheckInResult.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using QlikBar.SDK.DTOs;

namespace QlikBar.SDK.Results
{
    /// <summary>
    /// Class CheckInResult
    /// </summary>
    public class CheckInResult
    {
        /// <summary>
        /// Gets or sets the check in id.
        /// </summary>
        /// <value>The check in id.</value>
        [JsonProperty("id")]
        public int CheckInId { get; set; }

        /// <summary>
        /// Gets or sets the earned points.
        /// </summary>
        /// <value>The earned points.</value>
        [JsonProperty("earnedPoints")]
        public int EarnedPoints { get; set; }

        /// <summary>
        /// Gets or sets the total points.
        /// </summary>
        /// <value>The total points.</value>
        [JsonProperty("totalPoints")]
        public int TotalPoints { get; set; }

        /// <summary>
        /// Gets or sets the check ins.
        /// </summary>
        /// <value>The check ins.</value>
        [JsonProperty("checkIns")]
        public int CheckIns { get; set; }

        /// <summary>
        /// Gets or sets the name of the local.
        /// </summary>
        /// <value>The name of the local.</value>
        [JsonProperty("local")]
        public string LocalName { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the welcome message.
        /// </summary>
        /// <value>The welcome message.</value>
        [JsonProperty("welcome")]
        public string WelcomeMessage { get; set; }

        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>The table.</value>
        [JsonProperty("table")]
        public Table Table { get; set; }
    }
}
