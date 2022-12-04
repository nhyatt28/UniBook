using FirstDemoCore.Models;
using FirstDemoCore.Models.New_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoCore.Controllers
{
    public class HomeController : Controller
    {

        

        Customer myCustomer;
        Movie myMovie;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyCustomer()
        {
            myCustomer = new Customer();
            myCustomer.Id = 1;
            myCustomer.FirstName = "Jon";
            myCustomer.LastName = "Omar";
            myCustomer.Phone = "720-378-1880";
            myCustomer.Address = "1821 E Harmony Rd";
            myCustomer.DOB = new DateTime(2001, 3, 20, 16, 20, 00);

            return View(myCustomer);
        }

        public IActionResult MyMovie()
        {
            myMovie = new Movie();
            myMovie.Id = 1;
            myMovie.Genre = "Horror";
            myMovie.Title = "The Balogne Sandwhich That Kills";
            myMovie.ReleaseDate = new DateTime(2013, 10, 31, 00, 00, 00);
            myMovie.Price = "Free-99";

            return View(myMovie);
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult MyView()
        {
            return View();
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
