using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Models;
using Newtonsoft.Json;


namespace WeatherForecast.AppCode
{
     public class JsonParse
    {
        public JsonParse(string jsonCountries, string jsonCities)
        {
            this._jsonCountries = jsonCountries;
            this._jsonCities = jsonCities;
        }

        readonly string _jsonCountries;
        readonly string _jsonCities;
        public List<Country> GetCountries(List<City> cities)
        {
            bool isCountryFound = false;
            List<Country> countries = new List<Country>();
            foreach (City city in cities)
            {
                foreach (Country country in countries)
                {
                    if (city.Country == country.ShortName)
                    {
                        country.Cities.Add(city);
                        isCountryFound = true;
                        break;
                    }
                }
                if (!isCountryFound)
                {
                    countries.Add(CreateCountry(city.Country, _jsonCountries));
                    countries.Last().Cities.Add(city);
                }
                isCountryFound = false;
            }
            return countries;
        }
        public List<City> GetCities()
        {
             return JsonConvert.DeserializeObject<List<City>>(_jsonCities);
        }
        private Country CreateCountry(string shortName, string jsonCountries)
        {
            JObject jsonData = JObject.Parse(jsonCountries);
            string fullName = (jsonData.SelectToken(shortName)).ToString();

            return new Country()
            {
                ShortName = shortName,
                FullName = fullName
            };
        }
    }
}