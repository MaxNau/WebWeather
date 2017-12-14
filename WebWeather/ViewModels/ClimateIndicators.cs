using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebWeather.Services.Convertors;

namespace WebWeather.ViewModels
{
    [JsonConverter(typeof(ClimateIndicatorsConverter))]
    public class ClimateIndicators
    {
        public Atmospheric Atmospheric { get; set; }
        public Hydrospheric Hydrospheric { get; set; }
        public Lithospheric Lithospheric { get; set; }
        public DateTime Date { get; set; }
        public IList<WeatherDetails> WeatherDetails { get; set; }
    }
}