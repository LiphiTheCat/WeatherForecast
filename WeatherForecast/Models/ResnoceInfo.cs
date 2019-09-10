using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class ResnoceInfo
    {
        public ResnoceInfo(TemperatureInfo tempInfo, string city)
        {
            this.TempInfo = tempInfo;
            this.City = city;
        }

        public TemperatureInfo TempInfo { get; set; }
        public string City { get; set; }

    }
}
