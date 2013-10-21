using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QlikBar.SDK.DTOs
{

    public class MobileResponse
    {
        [JsonProperty("success")]
        public int Success { get; set; }
    }

    public class MobileResponse<TData> : MobileResponse
    {


        [JsonProperty("result")]
        public TData Data { get; set; }
    }
}
