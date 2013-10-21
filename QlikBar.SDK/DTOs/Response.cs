
using Newtonsoft.Json;

namespace QlikBar.SDK.DTOs
{

   
    public class Response
    {


        public Response()
        {
            
        }
        public Response(int code)
        {
            Code = code;

        }
  
   
        [JsonProperty("code")]
        public int Code { get; set; }
    }

    public class Response<TData> : Response
    {
       
        public Response(int code,TData data) : base(code) { Data = data; }

        public Response(int code) : base(code) {}

        public Response() {}

        [JsonProperty("result")]
        public TData Data { get; set; }
    }

    public class Response<TData, TErrors> : Response<TData>
    {
        public Response() {}

        public Response(int code) : base(code) {}

        public Response(int code, TData data) : base(code, data) {}

        public Response(int code, TData data, TErrors errors) : base(code, data) { Errors = errors; }

        [JsonProperty("errors")]
        public TErrors Errors { get; set; }

    }
}
