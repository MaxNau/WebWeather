using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WebWeather.ViewModels;

namespace WebWeather.Services.Convertors
{
    public class ClimateIndicatorsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ClimateIndicators);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            var atmospheric = new Atmospheric();
            atmospheric.Pressure = (double)obj.SelectToken("main.pressure");
            atmospheric.Humidity = (int)obj.SelectToken("main.humidity");
            atmospheric.SeaLevel = (double)obj.SelectToken("main.sea_level");
            atmospheric.GroundLevel = (double)obj.SelectToken("main.grnd_level");
            atmospheric.Cloudiness = (int)obj.SelectToken("clouds.all");
            atmospheric.Rain = (double?)obj.SelectToken("rain.3h");
            atmospheric.Snow = (double?)obj.SelectToken("snow.3h");

            var temperature = new Temperature();
            temperature.Current = (double)obj.SelectToken("main.temp");
            temperature.Min = (double)obj.SelectToken("main.temp_min");
            temperature.Max = (double)obj.SelectToken("main.temp_max");

            atmospheric.Temperature = temperature;

            ClimateIndicators indicators = new ClimateIndicators();
            var weather = obj.SelectToken("weather").ToObject<List<WeatherDetails>>();
            indicators.WeatherDetails = weather;
            indicators.Atmospheric = atmospheric;
            indicators.Date = (DateTime)obj.SelectToken("dt_txt");

            return indicators;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}