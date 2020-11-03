using Newtonsoft.Json;
using RestApiAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiAutomation.ParseHelpers
{
    public static class Serialize
    {
        public static string ToJson(this Planets self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
