// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-21-2013
// ***********************************************************************
// <copyright file="Response.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace QlikBar.SDK.DTOs
{


    /// <summary>
    /// Class Response
    /// </summary>
    public class Response
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        public Response()
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public Response(int code)
        {
            Code = code;

        }


        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>0=Success, -1=Unexpeted error, Other=Could not perform operation.</value>
        [JsonProperty("code")]
        public int Code { get; set; }
    }

    /// <summary>
    /// Class Response
    /// </summary>
    /// <typeparam name="TData">The type of the T data.</typeparam>
    public class Response<TData> : Response
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{TData}"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="data">The data.</param>
        public Response(int code,TData data) : base(code) { Data = data; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{TData}"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public Response(int code) : base(code) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{TData}"/> class.
        /// </summary>
        public Response() {}

        /// <summary>
        /// Gets or sets the result of the operation.
        /// </summary>
        /// <value>The result.</value>
        [JsonProperty("result")]
        public TData Data { get; set; }
    }

    /// <summary>
    /// Class Response
    /// </summary>
    /// <typeparam name="TData">The type of the T data.</typeparam>
    /// <typeparam name="TErrors">The type of the T errors.</typeparam>
    public class Response<TData, TErrors> : Response<TData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response{TData, TErrors}"/> class.
        /// </summary>
        public Response() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{TData, TErrors}"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public Response(int code) : base(code) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{TData, TErrors}"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="data">The data.</param>
        public Response(int code, TData data) : base(code, data) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{TData, TErrors}"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="data">The data.</param>
        /// <param name="errors">The errors.</param>
        public Response(int code, TData data, TErrors errors) : base(code, data) { Errors = errors; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>The errors.</value>
        [JsonProperty("errors")]
        public TErrors Errors { get; set; }

    }
}
