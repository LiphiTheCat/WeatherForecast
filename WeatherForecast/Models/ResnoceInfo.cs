using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class ResponceInfo
    {
        public ResponceInfo(TemperatureInfo main, string city)
        {
            this.Main = main;
            this.Name = city;
        }
        public ResponceInfo() { }
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }

    }
}
