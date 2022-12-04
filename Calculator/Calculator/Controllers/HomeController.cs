using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;



namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
       /* public IActionResult Index()
        {

            return View();
        } */

      

        [HttpPost]
        public IActionResult Index(AddModel model, string Calculate)

        {
          

            switch (Calculate) // changed if statements below to switch statement for better coding practices

            {
                case "Add":
                    model.Result = model.Number1 + model.Number2;
                    break;
                case "Subtract":
                    model.Result = model.Number1 - model.Number2;
                    break;
                case "Divide":
                    model.Result = model.Number1 / model.Number2;
                    break;
                case "Multiply":
                    model.Result = model.Number1 * model.Number2;
                    break;
            }
             /*  

            if (Calculate == "Add")
            {
                model.Result = model.Number1 + model.Number2;
            }
            if (Calculate == "Subtract")
            {
                model.Result = model.Number1 - model.Number2;
            }
            if (Calculate == "Multiply")
            {
                model.Result = model.Number1 * model.Number2;
            }
            if (Calculate == "Divide")
            {
                model.Result = model.Number1 / model.Number2;
            }

            */

            return View(model);

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
