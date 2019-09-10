using FreeGeoIPCore;
using FreeGeoIPCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using WeatherForecast.AppCode.Location;
using WeatherForecast.Models;
using System.Net;
using System.IO;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IAppCodeLocation _appLocation;

        public HomeController(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            this._appLocation = new AppCodeLocation();
            this._httpContextAccessor = httpContextAccessor;
            this._config = config;
            
        }

        public IActionResult Index()
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q=Moscow,ru&units=metric&appid=0cb7dbe4262ea27ff9c4b58570ed6fae";

            HttpWebRequest web = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse webResponse = (HttpWebResponse)web.GetResponse();

            

            string response;

            using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
                js
            }
            return View();
        }

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

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
