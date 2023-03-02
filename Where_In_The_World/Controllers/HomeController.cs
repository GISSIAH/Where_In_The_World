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
        public IActionResult Index(string countrySearch, string region, int? page)
        {

            
            int countryListSize = 8;
            int pageNumber = (page ?? 1);

            try
            {
                var allCountries = _countryService.GetCountries();
                if (countrySearch != null)
                {
                    ViewData["countrySearch"] = countrySearch;
                    ViewData["searchActive"] = true;
                    var searchCountries = _countryService.SearchCountries(countrySearch);
                    if (region != null)
                    {
                        ViewData["region"] = region;
                        if (region == "All")
                        {
                            return View(searchCountries.ToPagedList(pageNumber, countryListSize));
                        }
                        else
                        {
                            var regionCountries = searchCountries.Where(c => c.region == region);
                            return View(regionCountries.ToPagedList(pageNumber, countryListSize));
                        }


                    }
                    else
                    {
                        return View(searchCountries.ToPagedList(pageNumber, countryListSize));
                    }
                }
                else
                {
                    ViewData["searchActive"] = false;
                    if (region != null)
                    {
                        ViewData["region"] = region;
                        if (region == "All")
                        {
                            return View(allCountries.ToPagedList(pageNumber, countryListSize));
                        }
                        else
                        {
                            var regionCountries = allCountries.Where(c => c.region == region);
                            return View(regionCountries.ToPagedList(pageNumber, countryListSize));
                        }
                    }
                    else
                    {

                        return View(allCountries.ToPagedList(pageNumber, countryListSize));
                    }

                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                ViewBag.errorMessage = "an error occured fetching countries, please make sure you have an internet connection. If the issue persist, contact the system developer";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            try
            {
                var country = _countryService.GetCountry(id);

                if (country != null)
                {
                    return View(country);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                ViewBag.errorMessage = "an error occured fetching a country, please make sure you have an internet connection. If the issue persist, contact the system developer";
                return View();
            }
            

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}