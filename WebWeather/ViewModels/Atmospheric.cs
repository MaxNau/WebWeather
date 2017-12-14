
namespace WebWeather.ViewModels
{
    public class Atmospheric
    {
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public double SeaLevel { get; set; }
        public double GroundLevel { get; set; }
        public int Cloudiness { get; set; }
        public double? Rain { get; set; }
        public double? Snow { get; set; }
        public Temperature Temperature { get; set; }
    }
}