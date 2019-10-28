using FreeGeoIPCore;
using FreeGeoIPCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using WeatherForecast.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using WeatherForecast.AppCode;
using System.Collections;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        public HomeController(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._config = config;

        }
        [HttpGet]
        public IActionResult Index(string CityName)
        {
            if (CityName == null) CityName = "Moscow";

            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + CityName + "&units=metric&appid=0cb7dbe4262ea27ff9c4b58570ed6fae";

            HttpWebRequest web = (HttpWebRequest)WebRequest.Create(url);

            string response;

            using (HttpWebResponse webResponse = (HttpWebResponse)web.GetResponse())
            {

                using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
            }
            ResponceInfo responceInfo = JsonConvert.DeserializeObject<ResponceInfo>(response);
            ViewBag.responceInfo = responceInfo;
            return View();
        }
        
       
        [HttpGet]
        public JsonResult GetCountry(string country)
        {
            if (country != "All")
            {
                return Json(CountryList.Countries.Find(x => x.ShortName == country));
            }
            else
            {
                 return Json(CountryList.Countries);
            }
        }

        [HttpGet]
        public JsonResult GetCapitals(string country)
        {
            if (country != "All")
            {
                return Json(CountryList.Countries.Find(x => x.ShortName == country));
            }
            else
            {
                return Json(CountryList.Countries);
            }
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
