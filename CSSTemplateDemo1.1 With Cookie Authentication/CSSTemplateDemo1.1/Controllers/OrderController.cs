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
    public class OrderController : Controller
    {

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {

            string orderID = fromColl["orderID"];
            string date = fromColl["Date"];
            string customerID = fromColl["CustomerID"];

            DemoContext demoContext = new DemoContext();
            List<Order> searchOrder = new List<Order>();

            if (!string.IsNullOrEmpty(orderID))
            {
                searchOrder = demoContext.Orders.Where(x => x.ID.ToString() == orderID).ToList();
            }
            else
            if (!string.IsNullOrEmpty(date))
            {
                searchOrder = demoContext.Orders.Where(x => x.OrderDate == DateTime.Parse(date)).ToList();
            }
            else
            if (!string.IsNullOrEmpty("temID"))

            {
                //complete this part
                //searchOrder = demoContext.Orders.Where(x => x.OrderItems.Contains().ToList();
            }
            else
            {
                ViewData["ErrorMessage"] = new List<string> { "showing the list of all orders, no search criteria was selected" };
                searchOrder = demoContext.Orders.ToList();
            }
            return View(searchOrder);

        }
        [HttpGet]
        public IActionResult Orders(string orderID)
        {
            DemoContext demoContext = new DemoContext();
            Order order = new Order();

            if (!string.IsNullOrEmpty(orderID))
            {
                //complete this part
                order = demoContext.Orders.Where(x => x.ID.ToString() == orderID).FirstOrDefault();
            }
            if (order == null)
                order = new Order();
            return View(order);
        }

        [HttpPost]
        public IActionResult Orders(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {

            // take a look at the method CustomerProfile in the CustomerController and complete the steps required here
            // basically you will have the same steps but use the Item class instead of Customer
            // just like CustomerController -> public IActionResult CustomerProfile(Microsoft.AspNetCore.Http.IFormCollection fromColl)
            string orderID = fromColl["orderID"];
            // complete the rest of the data mapping here, including other attributes, customet id, date, etc.. add buttons as well..
            string AddButton = fromColl["AddButton"];
            //string UpdateButton = ...
            //string DeleteButton = ....


            Order myOrder = new Order();

            if (string.IsNullOrEmpty(orderID))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter code" };                
            }
            // complete the rest of if else satements here
            else
            {
                myOrder = new Order();
                myOrder.ID = int.Parse(orderID);
                
                if (!string.IsNullOrEmpty(AddButton))
                {
                    AddItem(myOrder);
                }
                else
                if (!string.IsNullOrEmpty("complete this part"))
                {
                    // complete this part
                }
                else
                if (!string.IsNullOrEmpty("complete this part"))
                {
                    // complete this part
                }
            }
            return View();
        }

        public Order AddItem(Order Order)
        {
            // complete this part similar to AddCustomer method in CustomerController class
            //CustomerController -> AddCustomer
           
            return Order;
        }
        public Order UpdateItem(Order order)
        {
            // complete this part similar to UpdateCustomer method in CustomerController class
            // CustomerController -> updateCustomer
           
            return order;
        }
        public Order DeleteItem(Order order)
        {
            // complete this part similar to DeleteCustomer method in CustomerController class
           
            return order;
        }




    }
}
