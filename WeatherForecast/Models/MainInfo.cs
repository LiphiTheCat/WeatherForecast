﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class MainInfo
    {
       public float Temp { get; set; }
       public float Temp_max { get; set; }
       public float Temp_min { get; set; }
       public float Pressure { get; set; }
       public float Humidity { get; set; }
    }
}