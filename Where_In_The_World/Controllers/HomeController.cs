using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using System.Diagnostics;
using Where_In_The_World.Models;
using Where_In_The_World.Services;

namespace Where_In_The_World.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryService _countryService;
        public HomeController(ILogger<HomeController> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        public IActionResult Index(int? page)
        {
            var countries = _countryService.GetCountries();
  

            int countryListSize = 8;
            int pageNumber = (page ?? 1);
            return View(countries.ToPagedList(pageNumber, countryListSize));
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}