using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWeather.Models
{

    public partial class Weather
    {
        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("cnt")]
        public long Cnt { get; set; }

        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("list")]
        public List[] List { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }
    }

    public partial class List
    {
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("dt_txt")]
        public string DtTxt { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("snow")]
        public Rain Snow { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("weather")]
        public PurpleWeather[] Weather { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }

    public partial class Wind
    {
        [JsonProperty("deg")]
        public double Deg { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }
    }

    public partial class PurpleWeather
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }
    }

    public partial class Sys
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }

    public partial class Rain
    {
        [JsonProperty("3h")]
        public double? The3h { get; set; }
    }

    public partial class Main
    {
        [JsonProperty("grnd_level")]
        public double GrndLevel { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("sea_level")]
        public double SeaLevel { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("temp_kf")]
        public double TempKf { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }
    }

    public partial class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }

    public partial class City
    {
        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Coord
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public partial class Weather
    {
        public static Weather FromJson(string json) => JsonConvert.DeserializeObject<Weather>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Weather self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}