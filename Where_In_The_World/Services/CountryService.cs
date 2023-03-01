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
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<CountryModel> GetCountries()
        {
            List<CountryModel> countryList = new List<CountryModel>();

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

        public ExtendedCountryModel GetCountry(string name)
        {
            var response = _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{name}").Result;

            var countryObjects = response.Content.ReadFromJsonAsync<IEnumerable<ExtendedCountryModel>>().Result;
            var c = countryObjects.FirstOrDefault();
  
            var country = new ExtendedCountryModel() { population = c.population, region = c.region, currencies=c.currencies };

            if (c.flags != null)
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

            if (c.capital != null)
            {
                country.capital = c.capital;

            }
            else
            {
                country.capital = null;
            }

            if(c.languages != null)
            {
                country.languages = c.languages;
            }
            else
            {
                country.languages = null;
            }

            if(c.borders != null)
            {
                country.borders = c.borders;
            }
            else
            {
                country.borders = new List<string>();
            }



            return country;

        }

        public List<CountryModel>? SearchCountries(string name)
        {
            List<CountryModel> countryList = new List<CountryModel>();

            var response = _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{name}").Result;

            var countryObjects = response.Content.ReadFromJsonAsync<IEnumerable<CountryModel>>().Result;

            if(countryObjects != null)
            {
                foreach (var c in countryObjects)
                {

                    var country = new CountryModel() { population = c.population, region = c.region };
                    if (c.flags != null)
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

                    if (c.capital != null)
                    {
                        country.capital = c.capital;

                    }
                    else
                    {
                        country.capital = new List<string> { ""};
                    }

                    countryList.Add(country);


                };

            }


            return countryList;
        }
    
        
    }
}
