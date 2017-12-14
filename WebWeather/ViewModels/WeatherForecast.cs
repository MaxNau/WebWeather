using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWeather.ViewModels
{
    public class WeatherForecast
    {
        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("list")]
        public IList<ClimateIndicators> ClimateIndicators { get; set; }

        public static WeatherForecast FromJson(string json) => JsonConvert.DeserializeObject<WeatherForecast>(json, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            ObjectCreationHandling = ObjectCreationHandling.Auto
        };

    }
}