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
using System.Collections.Generic;

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
        public IActionResult Index(string CityName, string Units)
        {
            if (CityName == null) CityName = "Moscow";

            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + CityName + "&units=" + Units + "&appid=0cb7dbe4262ea27ff9c4b58570ed6fae";

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
        public JsonResult GetCountries()
        {
            List<string> countries = new List<string>();
            foreach (Country country in CountryList.Countries)
            {
                
                countries.Add(country.FullName);
            }
            return Json(countries);
        }

        [HttpGet]
        public JsonResult GetCities(string country)
        {
            List<string> GetCountryName(Country country1)
            {
                List<string> citiesName = new List<string>();
                foreach(City c in country1.Cities)
                {
                    citiesName.Add(c.Name);
                }
                return citiesName;
            }
            return Json(GetCountryName(CountryList.Countries.Find(x => x.FullName == country)));

        }

        [HttpGet]
        public JsonResult GetCapital(string country)
        {
            return Json(CapitalList.Capitals.Find(x => x.Country.FullName == country).City.Name);

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
