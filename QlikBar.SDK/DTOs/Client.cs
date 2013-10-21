using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QlikBar.SDK.DTOs
{
   
        public class Client
        {

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("gender")]
            public string Gender { get; set; }

            [JsonProperty("paseBerde")]
            public string PaseBerde { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("province")]
            public string Province { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("checkIns")]
            public int CheckIns { get; set; }

            [JsonProperty("points")]
            public int Points { get; set; }

            [JsonProperty("zipCode")]
            public string ZipCode { get; set; }

            [JsonProperty("birthDate")]
            public DateTime? BirthDate { get; set; }

            public override string ToString() { return Id + " - " + FirstName+" "+LastName; }
        

    }

}
