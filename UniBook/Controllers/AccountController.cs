using UniBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UniBook.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email))
            {
                ViewData["ErrorList"] = new List<string> { "Please enter your email." };
            }
            else
             if (string.IsNullOrEmpty(Password))
            {
                ViewData["ErrorList"] = new List<string> { "Please enter your password." };
            }
            else
            {
                DemoContext demoContext = new DemoContext();

                RegisterStudent searchStudent = demoContext.RegisterStudents.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();

                if (searchStudent != null)
                {
                    var claim = new List<Claim> {

                        new Claim(ClaimTypes.Role, searchStudent.Email),
                        new Claim(ClaimTypes.Hash, searchStudent.Password),
                        new Claim(ClaimTypes.Name, searchStudent.Fname + " " + searchStudent.LName),

                    };

                    var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principle = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, principle, props).Wait();
                    return RedirectToAction("Profile", "Account");

                }
                else
                {
                    ViewData["ErrorList"] = new List<string> { "User not found" };
                    return View();
                }
            }
            return await  Task.FromResult(View());
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
          
            await HttpContext.SignOutAsync();

            if (HttpContext.SignOutAsync().IsCompletedSuccessfully)
            {
                TempData["SuccessMessage"] = new List<string> { "Loggout Completed Successfully. Goodbye!" };
                return RedirectToAction("Index", "Home", ViewData);
            } else
            {
                TempData["ErrorList"] = new List<string> { "Loggout Unsuccessful. Redirecting to Account Profile." };
                return RedirectToAction("Profile", "Account", "LogoutUnsuccessful");
            }
           
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {

            string fname = fromColl["FName"];
            string lname = fromColl["LName"];
            string email = fromColl["Email"];
            string username = fromColl["Username"];
            string password = fromColl["Password"];

            if (string.IsNullOrEmpty(fname))
            {
                ViewData["ErrorList"] = new List<string> { "Please enter your First name." };
            }
            else
            if (string.IsNullOrEmpty(lname))
            {
                ViewData["ErrorList"] = new List<string> { "Please enter your Last name." };
            }
            else
            if (string.IsNullOrEmpty(email))
            {
                ViewData["ErrorList"] = new List<string> { "Please enter your Email." };
            }
            else
            if (string.IsNullOrEmpty(username))
            {
                ViewData["ErrorList"] = new List<string> { "Please enter your Username." };
            }
            else
            if (string.IsNullOrEmpty(password))
            {
                ViewData["ErrorList"] = new List<string> { "Please enter your Password." };
            }
            else
            {
                RegisterStudent NewStudent = new RegisterStudent();
            
                NewStudent.Fname = fname;
                NewStudent.LName = lname;
                NewStudent.Email = email;
                NewStudent.Username = username;
                NewStudent.Password = password;

                DemoContext demoContext = new DemoContext();
                demoContext.RegisterStudents.Add(NewStudent);
                demoContext.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return await Task.FromResult(View());
        }

        [Authorize]

       // [HttpGet]
        public IActionResult Sell(string BookID)
        {
            DemoContext demoContext = new DemoContext();
            Textbook searchTxtBook = new Textbook();
               
                searchTxtBook = new Textbook();
            
            return View(searchTxtBook);
        }

       // [Authorize]

        [HttpPost]
        public async Task<ActionResult> Sell(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {

            string BookID = fromColl["BookID"];
            string ISBN = fromColl["ISBN"];
            string Title = fromColl["Title"];
            string Description = fromColl["Description"];
            string Publisher = fromColl["Publisher"];
            string Author = fromColl["Author"];
            string Edition = fromColl["Edition"];
            string Condition = fromColl["Condition"];
            string Price = fromColl["Price"];
            string AddButton = fromColl["AddButton"];
            Textbook searchTxtBook = new Textbook();


            
             if (string.IsNullOrEmpty(ISBN))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the ISBN#." };
            }
            else
             if (string.IsNullOrEmpty(Title))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Title." };
            }
            else
             if (string.IsNullOrEmpty(Description))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Description." };
            }
            else
             if (string.IsNullOrEmpty(Publisher))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Publisher." };
            }
            else
             if (string.IsNullOrEmpty(Author))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Author." };
            }
            else
             if (string.IsNullOrEmpty(Edition))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Edition." };
            }
            else
             if (string.IsNullOrEmpty(Condition))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Condition." };
            }
            else
             if (string.IsNullOrEmpty(Price))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Price." };
            }
            else
            {
                searchTxtBook = new Textbook();

                searchTxtBook.BookID = 1;
                //searchTxtBook.BookID = long.Parse(BookID);
                searchTxtBook.ISBN = int.Parse(ISBN);
                searchTxtBook.Title = Title;
                searchTxtBook.Description = Description;
                searchTxtBook.Publisher = Publisher;
                searchTxtBook.Author = Author;
                searchTxtBook.Edition = short.Parse(Edition);
                searchTxtBook.Condition = Condition;
                searchTxtBook.Price = int.Parse(Price);

                if (!string.IsNullOrEmpty(AddButton))
                {
                    AddTxtBook(searchTxtBook);
                }
            }
            return await Task.FromResult(View(searchTxtBook));
        }

        public Textbook AddTxtBook(Textbook txtBook)
        {
           
            DemoContext demoContext = new DemoContext();
            Textbook book = demoContext.Textbooks.OrderBy(s => s.BookID).LastOrDefault();
            txtBook.BookID = book.BookID + 1;

            demoContext.Textbooks.Add(txtBook);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Textbook added successfully" };
            return txtBook;
        }
        public Textbook UpdateTxtBook(Textbook txtBook)
        {

            DemoContext demoContext = new DemoContext();
            demoContext.Textbooks.Update(txtBook);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Textbook updated successfully" };
            return txtBook;
        }
        public Textbook DeleteTxtBook(Textbook txtBook)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Textbooks.Remove(txtBook);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Textbook deleted successfully" };
            return txtBook;
        }


      
        [HttpGet]
        public IActionResult Buy(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {
            DemoContext demoContext = new DemoContext();
            List<Textbook> searchbook = new List<Textbook>();

            string BookID = fromColl["BookID"];
            string ISBN = fromColl["ISBN"];
            string Title = fromColl["Title"];
            string Description = fromColl["Description"];
            string Publisher = fromColl["Publisher"];
            string Author = fromColl["Author"];
            string Edition = fromColl["Edition"];
            string Condition = fromColl["LName"];
            string Price = fromColl["Price"];

            searchbook = demoContext.Textbooks.ToList();

            return View(searchbook);
        }



        [Authorize]
        [HttpGet]
        public IActionResult UpdateBook(string BookID)
        {
            DemoContext demoContext = new DemoContext();
            Textbook searchbook = new Textbook();

            if (!string.IsNullOrEmpty(BookID))
            {
                searchbook = demoContext.Textbooks.Where(x => x.BookID.ToString() == BookID).FirstOrDefault();
            }
            if (searchbook == null)
            {
                ViewData["ErrorMessage"] = new List<string> { "customer id not found" };
                searchbook = new Textbook();
            }

            return View(searchbook);
        }
       
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> UpdateBook(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {

            string BookID = fromColl["BookID"];
            string ISBN = fromColl["ISBN"];
            string Title = fromColl["Title"];
            string Description = fromColl["Description"];
            string Publisher = fromColl["Publisher"];
            string Author = fromColl["Author"];
            string Edition = fromColl["Edition"];
            string Condition = fromColl["Condition"];
            string Price = fromColl["Price"];
           
            string UpdateButton = fromColl["UpdateButton"];
            string DeleteButton = fromColl["DeleteButton"];
            Textbook searchTxtBook = new Textbook();



            if (string.IsNullOrEmpty(ISBN))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the ISBN#." };
            }
            else
            if (string.IsNullOrEmpty(Title))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Title." };
            }
            else
            if (string.IsNullOrEmpty(Description))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Description." };
            }
            else
            if (string.IsNullOrEmpty(Publisher))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Publisher." };
            }
            else
            if (string.IsNullOrEmpty(Author))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Author." };
            }
            else
            if (string.IsNullOrEmpty(Edition))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Edition." };
            }
            else
            if (string.IsNullOrEmpty(Condition))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Condition." };
            }
            else
            if (string.IsNullOrEmpty(Price))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter the Price." };
            }
            else
            {
                searchTxtBook = new Textbook();

                
                searchTxtBook.BookID = long.Parse(BookID);
                searchTxtBook.ISBN = int.Parse(ISBN);
                searchTxtBook.Title = Title;
                searchTxtBook.Description = Description;
                searchTxtBook.Publisher = Publisher;
                searchTxtBook.Author = Author;
                searchTxtBook.Edition = short.Parse(Edition);
                searchTxtBook.Condition = Condition;
                searchTxtBook.Price = int.Parse(Price);

                if (!string.IsNullOrEmpty(UpdateButton))
                {
                    UpdateTxtBook(searchTxtBook);
                }
                else
                if (!string.IsNullOrEmpty(DeleteButton))
                {
                    DeleteTxtBook(searchTxtBook);
                }
            }
            return await Task.FromResult(View(searchTxtBook));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Update(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {

            string BookID = fromColl["BookID"];
            string ISBN = fromColl["ISBN"];
            string Title = fromColl["Title"];
            string Description = fromColl["Description"];
            string Publisher = fromColl["Publisher"];
            string Author = fromColl["Author"];
            string Edition = fromColl["Edition"];
            string Condition = fromColl["LName"];
            string Price = fromColl["Price"];

            DemoContext demoContext = new DemoContext();
            List<Textbook> searchbook = new List<Textbook>();


            if (!string.IsNullOrEmpty(BookID))
            {
                searchbook = demoContext.Textbooks.Where(x => x.BookID.ToString() == BookID).ToList();
            }
            else
            if (!string.IsNullOrEmpty(ISBN))
            {
                searchbook = demoContext.Textbooks.Where(x => x.ISBN.ToString() == ISBN).ToList();
            }
            else
            if (!string.IsNullOrEmpty(Title))
            {
                searchbook = demoContext.Textbooks.Where(x => x.Title == Title).ToList();
            }
            else
            if (!string.IsNullOrEmpty(Description))
            {
                searchbook = demoContext.Textbooks.Where(x => x.Description == Description).ToList();
            }
            else
            if (!string.IsNullOrEmpty(Publisher))
            {
                searchbook = demoContext.Textbooks.Where(x => x.Publisher == Publisher).ToList();
            }
            else
            if (!string.IsNullOrEmpty(Author))
            {
                searchbook = demoContext.Textbooks.Where(x => x.Author == Author).ToList();
            }
            else
            if (!string.IsNullOrEmpty(Edition))
            {
                searchbook = demoContext.Textbooks.Where(x => x.Edition.ToString() == Edition).ToList();
            }
            else
            if (!string.IsNullOrEmpty(Condition))
            {
                searchbook = demoContext.Textbooks.Where(x => x.Condition == Condition).ToList();
            }
            else
            if (!string.IsNullOrEmpty(Price))
            {
                searchbook = demoContext.Textbooks.Where(x => x.Price.ToString() == Price).ToList();
            }
            else
            {
                ViewData["ErrorMessage"] = new List<string> { "showing the list of all textbooks, no search criteria was selected" };
                searchbook = demoContext.Textbooks.ToList();
            }

            return await Task.FromResult(View(searchbook));
        }
    }

}
