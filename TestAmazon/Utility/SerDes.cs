using Microsoft.Build.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TestAmazon.Utility
{
    public static class SerDes
    {
        public static string Serialize<T>(T value)
        {
            try
            {
                if (EqualityComparer<T>.Default.Equals(value, default(T)))
                {
                    return string.Empty;
                }
              

              return JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented,
                 new JsonSerializerSettings
                 { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
              
              
            } 
            catch (Exception ex)
            {
                //TODO
                //Check scrittura LOG
                var innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = ex.InnerException.Message;

            

                return string.Empty;
            }
        }

        public static T DeSerialize<T>(string json)
        {
            try
            {
                if (string.IsNullOrEmpty(json))
                {
                    return default(T);
                }

               
                return JsonConvert.DeserializeObject<T>(json);


                
            }
            catch(Exception ex){
                return default(T);

            }


        }
    }
}