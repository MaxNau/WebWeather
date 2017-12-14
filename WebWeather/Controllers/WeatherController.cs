using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebWeather.Models;
using WebWeather.ViewModels;

namespace WebWeather.Controllers
{
    public class WeatherController : Controller
    {
        string googleApiKey = "AIzaSyB0owicIujTXrZXC_JnAjzwB4gecBGSDVA";
        string Baseurl = "http://api.openweathermap.org/data/2.5/";
        // GET: Weather
        public async Task<ActionResult> Weather()
        {
            WeatherForecast model = null;
            List<List<ClimateIndicators>> grouped = null;
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("forecast?id=703448&units=metric&apikey=a69a52ddcd752165cf3574fa6b5c512e");
                double lat = 0;
                double lon = 0;
                //Checking the response is successful or not which is sent using HttpClient  
           
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    model = WeatherForecast.FromJson(EmpResponse);

                    lat = model.City.Coordinates.Latitude;
                    lon = model.City.Coordinates.Longitude;

                    grouped = model.ClimateIndicators.GroupBy(x => Convert.ToDateTime(x.Date).ToShortDateString()).Select(g => g.ToList()).ToList();
                }

                //HttpResponseMessage Res2 = await client.GetAsync("https://maps.googleapis.com/maps/api/elevation/json?locations="+lat+","+lon + "&key=" + googleApiKey);

                //if (Res2.IsSuccessStatusCode)
                //{
                //    var resp = Res2.Content.ReadAsStringAsync().Result;

                //    //var jRes
                //}
            }

            return View(grouped);
        }


    }
}