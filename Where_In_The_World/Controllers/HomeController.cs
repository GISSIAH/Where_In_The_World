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

        [HttpGet]
        public IActionResult Index(string countrySearch, int? page)
        {
            var allCountries = _countryService.GetCountries();
            int countryListSize = 8;
            int pageNumber = (page ?? 1);

            if (countrySearch != null)
            {

                ViewData["countrySearch"] = countrySearch;
                ViewData["searchActive"] = true;
                var searchCountries = _countryService.SearchCountries(countrySearch);
                

                return View(searchCountries.ToPagedList(pageNumber, countryListSize));
            }
            else
            {
                ViewData["searchActive"] = false;
                return View(allCountries.ToPagedList(pageNumber, countryListSize));
            }


            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}