using Where_In_The_World.Models;

namespace Where_In_The_World.Services
{
    public interface ICountryService
    {
        List<CountryModel> GetCountries();

        List<CountryModel>? SearchCountries(string name);
    }
}
