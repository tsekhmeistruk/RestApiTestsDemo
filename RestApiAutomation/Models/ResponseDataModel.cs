using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RestApiAutomation.Models
{
    public class ResponseDataModel<T>
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
