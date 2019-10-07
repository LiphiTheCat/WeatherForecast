using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class ResponceInfo
    {
        public ResponceInfo(TemperatureInfo main, string name)
        {
            this.Main = main;
            this.Name = name;
        }
        public ResponceInfo() { }
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }

    }
}
