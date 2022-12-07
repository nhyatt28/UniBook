using CSSTemplateDemo1._1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSTemplateDemo1._1.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {
            string custId = fromColl["CustId"];
            string fname = fromColl["FirstName"];
            string lname = fromColl["LastName"];
            string phone = fromColl["Phone"];
            string email = fromColl["Email"];
            string city = fromColl["City"];
            string state = fromColl["State"];

            DemoContext demoContext = new DemoContext();
            List<Customer> searchcustomers = new List<Customer>();

            if (!string.IsNullOrEmpty(custId))
            {
                searchcustomers = demoContext.Customers.Where(x => x.ID.ToString() == custId).ToList();
            }
            else
            if (!string.IsNullOrEmpty(fname))
            {
                searchcustomers = demoContext.Customers.Where(x => x.FName == fname).ToList();
            }
            else
            if (!string.IsNullOrEmpty(lname))
            {
                searchcustomers = demoContext.Customers.Where(x => x.LName == lname).ToList();
            }
            else
            if (!string.IsNullOrEmpty(phone))
            {
                searchcustomers = demoContext.Customers.Where(x => x.Phone == phone).ToList();
            }
            else
            if (!string.IsNullOrEmpty(email))
            {
                searchcustomers = demoContext.Customers.Where(x => x.Email == email).ToList();
            }
            else
            if (!string.IsNullOrEmpty(city))
            {
                searchcustomers = demoContext.Customers.Where(x => x.City == city).ToList();
            }
            else
            if (!string.IsNullOrEmpty(state))
            {
                searchcustomers = demoContext.Customers.Where(x => x.State == state).ToList();
            }
            else
            {
                ViewData["ErrorMessage"] = new List<string> { "showing the list of all customers, no search criteria was selected" };
                searchcustomers = demoContext.Customers.ToList();
            }
            return View(searchcustomers);
        }
        [HttpGet]
        public IActionResult CustomerProfile(string custId)
        {
            DemoContext demoContext = new DemoContext();
            Customer searchcustomer = new Customer();

            if (!string.IsNullOrEmpty(custId))
            {
                searchcustomer = demoContext.Customers.Where(x => x.ID.ToString() == custId).FirstOrDefault();
            }
            if (searchcustomer == null)
            {
                ViewData["ErrorMessage"] = new List<string> { "customer id not found" };
                searchcustomer = new Customer();
            }

            return View(searchcustomer);
        }
        [HttpPost]
        public IActionResult CustomerProfile(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {
            string custId = fromColl["CustId"];
            string fname = fromColl["FirstName"];
            string lname = fromColl["LastName"];
            string phone = fromColl["Phone"];
            string email = fromColl["Email"];
            string address1 = fromColl["Address1"];
            string address2 = fromColl["Address2"];
            string city = fromColl["City"];
            string state = fromColl["State"];

            string AddButton = fromColl["AddButton"];
            string UpdateButton = fromColl["UpdateButton"];
            string DeleteButton = fromColl["DeleteButton"];
            Customer MyCustomer = new Customer();

            if (string.IsNullOrEmpty(fname))
            {
                ViewData["ErrorMessage"] = new List<string> { "pleas enter first name" };
            }
            else
            if (string.IsNullOrEmpty(lname))
            {
                ViewData["ErrorMessage"] = new List<string> { "pleas enter last name" };
            }
            else
            if (string.IsNullOrEmpty(phone))
            {
                ViewData["ErrorMessage"] = new List<string> { "pleas enter phone" };
            }
            else
            if (string.IsNullOrEmpty(email))
            {
                ViewData["ErrorMessage"] = new List<string> { "pleas enter email" };
            }
            else
            if (string.IsNullOrEmpty(address1))
            {
                ViewData["ErrorMessage"] = new List<string> { "pleas enter address" };
            }
            else
            if (string.IsNullOrEmpty(city))
            {
                ViewData["ErrorMessage"] = new List<string> { "pleas enter city" };
            }
            else
            if (string.IsNullOrEmpty(state))
            {
                ViewData["ErrorMessage"] = new List<string> { "pleas enter state" };
            }
            else
            {
                MyCustomer = new Customer();
                MyCustomer.ID = int.Parse(custId);
                MyCustomer.FName = fname;
                MyCustomer.LName = lname;
                MyCustomer.Phone = phone;
                MyCustomer.Email = email;
                MyCustomer.Street1 = address1;
                MyCustomer.Street2 = address2;
                MyCustomer.City = city;
                MyCustomer.State = state;

                if (!string.IsNullOrEmpty(AddButton))
                {
                    AddCustomer(MyCustomer);
                }
                else
                if (!string.IsNullOrEmpty(UpdateButton))
                {
                    UpdateCustomer(MyCustomer);
                }
                else
                if (!string.IsNullOrEmpty(DeleteButton))
                {
                    DeleteCustomer(MyCustomer);
                }
            }

            return View(MyCustomer);
        }

        public Customer AddCustomer(Customer myCustomer)
        {
            myCustomer.ID = 0;
            DemoContext demoContext = new DemoContext();
            demoContext.Customers.Add(myCustomer);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Customer added successfully" };
            return myCustomer;
        }
        public Customer UpdateCustomer(Customer myCustomer)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Customers.Update(myCustomer);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Customer updated successfully" };
            return myCustomer;
        }
        public Customer DeleteCustomer(Customer myCustomer)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Customers.Remove(myCustomer);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Customer deleted successfully" };
            return myCustomer;
        }
    }
}
