using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class ResponceInfo
    {
        public ResponceInfo() { }
        public MainInfo Main { get; set; }
        public string Name { get; set; }
        public Wind Wind { get; set; }
        public Weather[] Weather { get; set; }
    }
}
