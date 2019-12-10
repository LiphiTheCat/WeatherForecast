using System.Collections.Generic;

namespace WeatherForecast.Models
{
    public class Country
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}
