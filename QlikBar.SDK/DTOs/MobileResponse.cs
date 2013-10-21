// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-17-2013
// ***********************************************************************
// <copyright file="MobileResponse.cs" company="">
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
    /// Class MobileResponse
    /// </summary>
    public class MobileResponse
    {
        /// <summary>
        /// Gets or sets the success.
        /// </summary>
        /// <value>The success.</value>
        [JsonProperty("success")]
        public int Success { get; set; }
    }

    /// <summary>
    /// Class MobileResponse
    /// </summary>
    /// <typeparam name="TData">The type of the T data.</typeparam>
    public class MobileResponse<TData> : MobileResponse
    {


        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("result")]
        public TData Data { get; set; }
    }
}
