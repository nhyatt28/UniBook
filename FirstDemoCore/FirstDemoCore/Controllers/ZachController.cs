using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoCore.Controllers
{
    public class ZachController : Controller
    {
        public IActionResult ZachsView()
        {
            return View(new FirstDemoCore.Models.New_Model.Customer { FirstName = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
