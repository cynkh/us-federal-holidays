using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapp.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return RedirectPermanent("Holidays");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "How to use the Holidays list.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
