using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using WeatherForecast.Models;

namespace WeatherForecast.AppCode
{
    static public class ResponseConfig
    {
        public static void Configuration()
        {
            string countriesShortUrl = "http://country.io/names.json";
            string capitalsUrl = "http://country.io/capital.json";

            string cityList;
            using (StreamReader streamReader = new StreamReader(File.OpenRead("cityList.json")))
            {
                cityList = streamReader.ReadToEnd();
            }

            JsonParse parse = new JsonParse(Responce(countriesShortUrl), cityList, Responce(capitalsUrl));
            CityList.City = parse.GetCities();
            CountryList.Countries = parse.GetCountries(CityList.City);
            CapitalList.Capitals = parse.GetCapitals(CountryList.Countries, CityList.City) ;
        }
        static private string Responce(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
