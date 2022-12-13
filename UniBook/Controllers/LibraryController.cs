using UniBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UniBook.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Books()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Purchase(string BookID)
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

        [HttpPost]
        public async Task<ActionResult> Purchase(Microsoft.AspNetCore.Http.IFormCollection fromColl)
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

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(Microsoft.AspNetCore.Http.IFormCollection fromColl)
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
