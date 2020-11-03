using Newtonsoft.Json;
using RestApiAutomation.ParseHelpers;
using System;
using System.ComponentModel;

namespace RestApiAutomation.Models
{
    [Description("api/planets")]
    public class Planets
    {
        [JsonProperty("climate")]
        public string Climate { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("diameter")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Diameter { get; set; }

        [JsonProperty("edited")]
        public DateTimeOffset Edited { get; set; }

        [JsonProperty("films")]
        public Uri[] Films { get; set; }

        [JsonProperty("gravity")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Gravity { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("orbital_period")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long OrbitalPeriod { get; set; }

        [JsonProperty("population")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Population { get; set; }

        [JsonProperty("residents")]
        public Uri[] Residents { get; set; }

        [JsonProperty("rotation_period")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long RotationPeriod { get; set; }

        [JsonProperty("surface_water")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long SurfaceWater { get; set; }

        [JsonProperty("terrain")]
        public string Terrain { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        public static Planets FromJson(string json) => JsonConvert.DeserializeObject<Planets>(json, Converter.Settings);
    }
}