//using CSSTemplateDemo1._1.Models;
using CSSTemplateDemo1._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSSTemplateDemo1._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*
            DemoContext demoContext = new DemoContext();
            
            List<Customer> customerlist= demoContext.Customers.ToList();
            

            Customer mycustomer = demoContext.Customers.Where(x => x.CustomerID == 1).FirstOrDefault();

            List<Customer> mycustomer2 = demoContext.Customers.Where(x => x.CustomerFirstName == "St*").ToList();

            List<Customer> mycustomer3 = demoContext.Customers.Where(x => x.City== "Fort Collins").ToList();

            List<Customer> mycustomer4 = demoContext.Customers.Where(x => x.City != "Fort Collins").ToList();


            List<Customer> mycustomer5 = demoContext.Customers.Where(x => x.CustomerDOB <= DateTime.Now.AddYears(-20)).ToList();

            List<Customer> mycustomer6 = demoContext.Customers.Where(x => x.Phone.StartsWith("720")).Union(demoContext.Customers.Where(x => x.Phone.StartsWith("970"))).ToList();
            mycustomer6.AddRange(demoContext.Customers.Where(x => x.Phone.StartsWith("303")).ToList());

            */







            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {
            /*
            string fname = fromColl["FirstName"];
            string lname = fromColl["LastName"];
            string email = fromColl["Email"];
            string Address = fromColl["Address"];
            string phone = fromColl["Phone"];           
            string password1 = fromColl["Password"];
            string password2 = fromColl["PasswordConfirm"];
            string agree = fromColl["Agree"];
            
            if (string.IsNullOrEmpty(fname))
            {
                ViewData["ErrorList"] = new List<string> { "pleas eenter your f name" };
            }
            else
            if (string.IsNullOrEmpty(lname))
            {
                ViewData["ErrorList"] = new List<string> { "pleas eenter your last name" };
            }
            else
            if (string.IsNullOrEmpty(email))
            {
                ViewData["ErrorList"] = new List<string> { "pleas eenter your f name" };
            }
            else
            {
                Customer NewCustomer = new Customer();
                NewCustomer.CustomerFirstName = fname;
                NewCustomer.CustomerLastName = lname;
                NewCustomer.Phone = phone;
                NewCustomer.AddressLine1 = Address;
                DemoContext demoContext = new DemoContext();
                demoContext.Customers.Add(NewCustomer);
                demoContext.SaveChanges();
            }*/
            return View();
        }

      

        public IActionResult Invoice()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult MyPage()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

     

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Customers()
        {
            
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
