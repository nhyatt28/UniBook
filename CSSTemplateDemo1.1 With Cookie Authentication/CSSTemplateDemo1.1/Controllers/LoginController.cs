using CSSTemplateDemo1._1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CSSTemplateDemo1._1.Controllers
{

    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                ViewData["ErrorList"] = new List<string> { "please enter your username" };
            }
            else
             if (string.IsNullOrEmpty(password))
            {
                ViewData["ErrorList"] = new List<string> { "please enter your password" };
            }
            else
            {
                DemoContext demoContext = new DemoContext();

                Customer searchcustomers = demoContext.Customers.Where(x => x.Email == username && x.Password == password).FirstOrDefault();

                if (searchcustomers != null)
                {
                    var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, searchcustomers.Role)
                };
                    var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principle = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, principle, props).Wait();
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewData["ErrorList"] = new List<string> { "User not found" };
                    return View();
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {

            string fname = fromColl["FirstName"];
            string lname = fromColl["LastName"];
            string email = fromColl["Email"];
            string Address = fromColl["Address"];
            string password = fromColl["Password"];
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
            if (string.IsNullOrEmpty(password))
            {
                ViewData["ErrorList"] = new List<string> { "pleas eenter your password" };
            }
            else
            {
                Customer NewCustomer = new Customer();
                NewCustomer.FName = fname;
                NewCustomer.LName = lname;
                NewCustomer.Phone = phone;
                NewCustomer.Street1 = Address;
                NewCustomer.Email = email;
                NewCustomer.Password = password;

                DemoContext demoContext = new DemoContext();
                demoContext.Customers.Add(NewCustomer);
                demoContext.SaveChanges();
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

    }
}
