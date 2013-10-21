// ***********************************************************************
// Assembly         : QlikBar.SDK
// Author           : Antonio Gil Espinosa
// Created          : 10-21-2013
//
// Last Modified By : Antonio Gil Espinosa
// Last Modified On : 10-17-2013
// ***********************************************************************
// <copyright file="Client.cs" company="">
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
    /// Class Client
    /// </summary>
        public class Client
        {

            /// <summary>
            /// Gets or sets the id.
            /// </summary>
            /// <value>The id.</value>
            [JsonProperty("id")]
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets the first name.
            /// </summary>
            /// <value>The first name.</value>
            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            /// <summary>
            /// Gets or sets the last name.
            /// </summary>
            /// <value>The last name.</value>
            [JsonProperty("lastName")]
            public string LastName { get; set; }

            /// <summary>
            /// Gets or sets the gender.
            /// </summary>
            /// <value>The gender.</value>
            [JsonProperty("gender")]
            public string Gender { get; set; }

            /// <summary>
            /// Gets or sets the pase berde.
            /// </summary>
            /// <value>The pase berde.</value>
            [JsonProperty("paseBerde")]
            public string PaseBerde { get; set; }

            /// <summary>
            /// Gets or sets the country.
            /// </summary>
            /// <value>The country.</value>
            [JsonProperty("country")]
            public string Country { get; set; }

            /// <summary>
            /// Gets or sets the province.
            /// </summary>
            /// <value>The province.</value>
            [JsonProperty("province")]
            public string Province { get; set; }

            /// <summary>
            /// Gets or sets the city.
            /// </summary>
            /// <value>The city.</value>
            [JsonProperty("city")]
            public string City { get; set; }

            /// <summary>
            /// Gets or sets the check ins.
            /// </summary>
            /// <value>The check ins.</value>
            [JsonProperty("checkIns")]
            public int CheckIns { get; set; }

            /// <summary>
            /// Gets or sets the points.
            /// </summary>
            /// <value>The points.</value>
            [JsonProperty("points")]
            public int Points { get; set; }

            /// <summary>
            /// Gets or sets the zip code.
            /// </summary>
            /// <value>The zip code.</value>
            [JsonProperty("zipCode")]
            public string ZipCode { get; set; }

            /// <summary>
            /// Gets or sets the birth date.
            /// </summary>
            /// <value>The birth date.</value>
            [JsonProperty("birthDate")]
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            public override string ToString() { return Id + " - " + FirstName+" "+LastName; }
        

    }

}
