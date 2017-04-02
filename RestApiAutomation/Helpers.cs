using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace RestApiAutomation
{
    public static class Helpers
    {
        public static string GetDescription<T>()
        {
            var descriptionAttribute = typeof(T)
                                       .GetCustomAttributes(typeof(DescriptionAttribute), true)
                                       .FirstOrDefault() as DescriptionAttribute;
            if(descriptionAttribute != null)
            {
                return descriptionAttribute.Description;
            }
            return null;
        }

        public static List<T> DeserializeList<T>(string jsonData)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }

        public static T Deserialize<T>(string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public static string Serialize<T>(T entity)
        {
            return JsonConvert.SerializeObject(entity);
        }

        public static string ResponseDataToJson(WebResponse response)
        {
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public static ResponseModel CreateResponseModel<T>(T respondeData, HttpStatusCode httpStatusCode)
        {
            return new ResponseModel() { HttpStatusCode = httpStatusCode, ResponseData = (T)respondeData };
        }

        public static ResponseModel CreateResponseModel(HttpStatusCode httpStatusCode)
        {
            return new ResponseModel() { HttpStatusCode = httpStatusCode };
        }
    }
}
