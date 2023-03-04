using Where_In_The_World.Models;

namespace Where_In_The_World.Services
{
    public interface ICountryService
    {
        List<Country> GetCountries();

        List<Country> SearchCountries(string name);

        ExtendedCountry? GetCountry(string name);
    }
}
