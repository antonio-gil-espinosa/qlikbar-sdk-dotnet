using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace QlikBar.SDK
{
    internal static class Utilities
    {



    
        public static string [] ToStringArray<T>(T [] array)
        {
            string [] ret = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
                ret[i] = Convert.ToString(array[i]);

            return ret;
        }

  

        
  
 

        

        public static byte[] ToBytes(string Input, Encoding Encoding = null)
        {
            return string.IsNullOrEmpty(Input) ? null : (Encoding ?? new UTF8Encoding()).GetBytes(Input);
        }

        public static void Write(Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }

        public static byte[] ReadAll(Stream stream)
        {
            byte[] array = new byte[stream.Length];

            stream.Read(array, 0, (int)stream.Length);

            return array;
        }
    }
}
