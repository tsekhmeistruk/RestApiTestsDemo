using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace RestApiAutomation.ParseHelpers
{
    public class JsonHelper
    {
        private string _configFilePath;
        public JsonHelper(string configFilePath)
        {
            _configFilePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"/" + configFilePath;
        }

        public string GetJsonValueByKey(string key)
        {
            string value;
            using (StreamReader r = new StreamReader(_configFilePath))
            {
                string json = r.ReadToEnd();
                var data = (JObject)JsonConvert.DeserializeObject(json);
                value = data[key].Value<string>();
            }
            return value;
        }

        public string[] GetJsonArrayByKey(string key)
        {
            string[] values;
            using (StreamReader r = new StreamReader(_configFilePath))
            {
                string json = r.ReadToEnd();
                JObject data = (JObject)JsonConvert.DeserializeObject(json);
                JArray array = (JArray)data[key];
                values = array.ToObject<string[]>();
            }
            return values;
        }
    }
}
