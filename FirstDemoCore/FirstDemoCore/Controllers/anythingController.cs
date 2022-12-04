using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoCore.Controllers
{
    public class anythingController : Controller
    {
        public IActionResult Index3()
        {
            return View();
        }
    }
}
