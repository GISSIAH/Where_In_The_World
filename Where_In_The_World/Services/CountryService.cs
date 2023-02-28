using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System;
using Where_In_The_World.Models;
using System.Security.Cryptography.Xml;
using System.Collections.Generic;

namespace Where_In_The_World.Services
{
    public class CountryService: ICountryService
    {
        private HttpClient _httpClient;
        public CountryService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://restcountries.com/v3.1");
        }

        public List<CountryModel> GetCountries()
        {
            List<CountryModel> countryList = new List<CountryModel>();

            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            
            var response = _httpClient.GetAsync("https://restcountries.com/v3.1/all").Result;

            var countryObjects = response.Content.ReadFromJsonAsync<IEnumerable<CountryModel>>().Result;
   
            foreach (var c in countryObjects)
            {
  
                var country = new CountryModel() { population=c.population, region=c.region};
                if(c.flags != null)
                {
                    country.flags = c.flags;
                }

                if (c.name.nativeName != null)
                {
                    country.name = c.name;
                }
                else
                {
                    country.name = new Name() { common = c.name.common, official = c.name.official, nativeName = null };
                }

                if(c.capital != null)
                {
                    country.capital = c.capital;

                }
                else
                {
                    country.capital = null;
                }
                
                countryList.Add(country);


            };


            return countryList;

        }
    }
}
