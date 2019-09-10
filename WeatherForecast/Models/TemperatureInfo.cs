using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class TemperatureInfo
    {
       public float CurentTemp { get; set; }
       public bool IsCelsius { get;set; }
       public float MaxTemp { get; set; }
       public float MinTemp { get; set; }

    }
}
