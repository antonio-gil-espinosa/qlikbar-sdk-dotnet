using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace QlikBar.SDK
{
    internal static class HttpHelper
    {
#if !DEBUG
        public static string baseUrl = "http://api.qlikbar.com";
#elif !LOCAL
        public static string baseUrl = "http://test.api.qlikbar.com";
#else
        public static string baseUrl = "http://localhost:1111";
#endif


        public static WebResponse Request(
          string Url,
          string Method = WebRequestMethods.Http.Get,
          Dictionary<string, string> Data = null,
          Version ProtocolVersion = null,
          string ContentType = "application/x-www-form-urlencoded",
          Encoding Encoding = null,
          bool KeepAlive = false,
          Dictionary<string, string> Headers = null)
        {
            Debug.WriteLine(string.Format("[{0} Request] {1}", Method, Url));
            Encoding encoding = Encoding ?? Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.KeepAlive = KeepAlive;
            request.ProtocolVersion = ProtocolVersion ?? HttpVersion.Version11;
            request.Method = Method;
            request.ContentType = ContentType;

            if (Headers != null)
                foreach (KeyValuePair<string, string> kpv in Headers)
                {
                    request.Headers.Add(kpv.Key, kpv.Value);
                    Debug.IndentLevel++;
                    Debug.WriteLine("HEADER - " + kpv.Key + " " + kpv.Value);
                    Debug.IndentLevel--;
                }

            byte[] byteArray = new byte[0];
            if (Data != null)
            {
                Debug.IndentLevel++;
                string postString = "";
                int i = 0;
                foreach (KeyValuePair<string, string> kpv in Data)
                {
                    if (i != 0)
                        postString += "&";
                    if (kpv.Value != null)
                    {
                        postString += kpv.Key + "=" + kpv.Value;
                        Debug.WriteLine("POST - " + kpv.Key + "=" + kpv.Value);
                    }
                    i++;
                }
                Debug.IndentLevel--;
                byteArray = Utilities.ToBytes(postString, encoding);
            }



            request.ContentLength = byteArray.Length;

            

            if (Method != "GET")
                using (Stream requestStream = request.GetRequestStream())
                    Utilities.Write(requestStream, byteArray);


            return request.GetResponse();
        }


        internal static string Post(string url, string apiKey, Dictionary<string,string> data = null)
        {
            HttpWebResponse webResponse = (HttpWebResponse)Request(baseUrl + "/" + url.TrimStart('/'), "POST", data, Headers: new Dictionary<string, string> { { "ApiKey", apiKey } });


            using (webResponse)
            using (StreamReader responseStream = new StreamReader(webResponse.GetResponseStream(), true))
            {
                return responseStream.ReadToEnd();
            }
   
        }

        internal static string Get(string url, int id,string password)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string> { { "Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(id + ":" + password)) } };
            HttpWebResponse webResponse = (HttpWebResponse)Request(baseUrl + "/" + url.TrimStart('/'), "GET", Headers: dictionary);


            using (webResponse)
            using (StreamReader responseStream = new StreamReader(webResponse.GetResponseStream(), true))
            {
                return responseStream.ReadToEnd();
            }
        }

        internal static string Post(string url, int id, string password, Dictionary<string, string> data = null)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string> { { "Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(id + ":" + password)) } };
            HttpWebResponse webResponse = (HttpWebResponse)Request(baseUrl + "/" + url.TrimStart('/'), "POST", data, Headers: dictionary);


            using (webResponse)
            using (StreamReader responseStream = new StreamReader(webResponse.GetResponseStream(), true))
            {
                return responseStream.ReadToEnd();
            }

        }

        internal static string Get(string url, string apiKey)
        {
            HttpWebResponse webResponse = (HttpWebResponse)Request(baseUrl + "/" + url.TrimStart('/'), "GET", Headers: new Dictionary<string, string> { { "ApiKey", apiKey } });


            using (webResponse)
            using (StreamReader responseStream = new StreamReader(webResponse.GetResponseStream(), true))
            {
                return responseStream.ReadToEnd();
            }
        }

    }
}
