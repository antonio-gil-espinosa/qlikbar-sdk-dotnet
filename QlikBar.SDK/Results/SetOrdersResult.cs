// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-17-2013
// ***********************************************************************
// <copyright file="SetOrdersResult.cs" company="">
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
    /// Class SetOrdersResult
    /// </summary>
    public class SetOrdersResult
    {
        /// <summary>
        /// Gets or sets the check in id.
        /// </summary>
        /// <value>The check in id.</value>
        [JsonProperty("checkIn")]
        public int CheckInId { get; set; }

        /// <summary>
        /// Gets or sets the orders id.
        /// </summary>
        /// <value>The orders id.</value>
        [JsonProperty("orders")]
        public int [] OrdersId { get; set; }
    }
}
