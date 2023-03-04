using System.Net.Http.Headers;
using Where_In_The_World.Models;

namespace Where_In_The_World.Services
{
    public class CountryService: ICountryService
    {
        private readonly HttpClient _httpClient;

        private const string baseUrl = "https://restcountries.com/v3.1";
        public CountryService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Country> GetCountries()
        {
            var response = _httpClient.GetAsync($"{baseUrl}/all").Result;

            var countryObjects = response.Content.ReadFromJsonAsync<IEnumerable<Country>>().Result;

            if (countryObjects != null)
            {
                return (List<Country>)countryObjects;
            }
            else
            {
                return new List<Country>();
            }
          
        }

        public ExtendedCountry? GetCountry(string name)
        {
            var response = _httpClient.GetAsync($"{baseUrl}/name/{name}").Result;

            var countryObjects = response.Content.ReadFromJsonAsync<IEnumerable<ExtendedCountry>>().Result;
            if(countryObjects != null)
            {
                var c = countryObjects.FirstOrDefault();
                return c;
            }
            else
            {
                return null;
            }
            

        }

        public List<Country> SearchCountries(string name)
        {

            var response = _httpClient.GetAsync($"{baseUrl}/name/{name}").Result;

            var countryObjects = response.Content.ReadFromJsonAsync<IEnumerable<Country>>().Result;

            if (countryObjects != null)
            {
                return (List<Country>)countryObjects;

            }
            else { 
            
                return new List<Country> { };
            }


        }
    
        
    }
}
