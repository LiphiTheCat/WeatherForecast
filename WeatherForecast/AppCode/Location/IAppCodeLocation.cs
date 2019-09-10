using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.AppCode.Location
{
    public interface IAppCodeLocation
    {
        string GetRequestIP(IHttpContextAccessor httpContextAccessor, bool tryUseXForwardHeader = true);
    }
}
 