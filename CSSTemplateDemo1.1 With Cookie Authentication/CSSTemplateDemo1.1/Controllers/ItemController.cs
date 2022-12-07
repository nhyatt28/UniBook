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

    public class ItemController : Controller
    {
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {

            string ItemId = fromColl["ItemId"];
            string code = fromColl["Code"];
            string description = fromColl["Description"];
            string quantity = fromColl["Quantity"];
           
            DemoContext demoContext = new DemoContext();
            List<Item> searchItems = new List<Item>();

            if (!string.IsNullOrEmpty(ItemId))
            {
                searchItems = demoContext.Items.Where(x => x.ID.ToString() == ItemId).ToList();
            }
            else
            if (!string.IsNullOrEmpty(code))
            {
                searchItems = demoContext.Items.Where(x => x.Code == code).ToList();
            }
            else
            if (!string.IsNullOrEmpty(description))
            {
                searchItems = demoContext.Items.Where(x => x.Description == ItemId).ToList();
            }
            else
            if (!string.IsNullOrEmpty(quantity))
            {
                searchItems = demoContext.Items.Where(x => x.Quantity >= int.Parse(quantity)).ToList();
            }
            else
            {
                ViewData["ErrorMessage"] = new List<string> { "showing the list of all items, no search criteria was selected" };
                searchItems = demoContext.Items.ToList();
            }
            return View(searchItems);

        }

        public IActionResult ItemProfile(string itemId)
        {
            DemoContext demoContext = new DemoContext();
            Item item = new Item();

            if (!string.IsNullOrEmpty(itemId))
            {
                item = demoContext.Items.Where(x => x.ID.ToString() == itemId).FirstOrDefault();
            }
            if (item == null)
                item = new Item();
            return View(item);
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult ItemProfile(Microsoft.AspNetCore.Http.IFormCollection fromColl)
        {

            // take a look at the method CustomerProfile in the CustomerController and complete the steps required here
            // basically you will have the same steps but use the Item class instead of Customer
            // just like CustomerController -> public IActionResult CustomerProfile(Microsoft.AspNetCore.Http.IFormCollection fromColl)
            string ItemId = fromColl["ItemId"];
            string code = fromColl["Code"];
            string description = fromColl["Description"];
            string quantity = fromColl["Quantity"];
            string price = fromColl["Price"];
            string details = fromColl["Details"];
            string type = fromColl["Type"];
            string AddButton = fromColl["AddButton"];
            string UpdateButton = fromColl["UpdateButton"];
            string DeleteButton = fromColl["DeleteButton"];

            Item myitem = new Item();

            if (string.IsNullOrEmpty(code))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter code" };
            }
            else
            if (string.IsNullOrEmpty(description))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter description" };
            }
            else
            if (string.IsNullOrEmpty(quantity))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter quantity" };
            }
            else
            if (string.IsNullOrEmpty(price))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter price" };
            }
            else
            if (string.IsNullOrEmpty(details))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter details" };
            }
            else
            if (string.IsNullOrEmpty(type))
            {
                ViewData["ErrorMessage"] = new List<string> { "please enter type" };
            }
            else
            {
                myitem = new Item();
                myitem.ID = int.Parse(ItemId);
                myitem.Code = code;
                myitem.Description = description;
                myitem.Quantity = int.Parse(quantity);
                
                Decimal prc;
                Decimal.TryParse(price, out prc);
                myitem.Price = prc;

                myitem.Details = details;
                myitem.Type = type;

                if (!string.IsNullOrEmpty(AddButton))
                {
                    AddItem(myitem);
                }
                else
                if (!string.IsNullOrEmpty(UpdateButton))
                {
                    UpdateItem(myitem);
                }
                else
                if (!string.IsNullOrEmpty(DeleteButton))
                {
                    DeleteItem(myitem);
                }
                return View(myitem);
            }
            return View();
        }

        public Item AddItem(Item item)
        {
            // complete this part similar to AddCustomer method in CustomerController class
            //CustomerController -> AddCustomer
            item.ID = 0;
            DemoContext demoContext = new DemoContext();
            demoContext.Items.Add(item);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Item added successfully" };
            return item;
        }
        public Item UpdateItem(Item item)
        {
            // complete this part similar to UpdateCustomer method in CustomerController class
            // CustomerController -> updateCustomer
            DemoContext demoContext = new DemoContext();
            demoContext.Items.Update(item);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Item updated successfully" };
            return item;
        }
        public Item DeleteItem(Item item)
        {
            // complete this part similar to DeleteCustomer method in CustomerController class
            item.ID = 0;
            DemoContext demoContext = new DemoContext();
            demoContext.Remove(item);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Item removed successfully" };
            return item;
        }


    }

}
