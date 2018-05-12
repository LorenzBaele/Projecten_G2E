using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetG2E.Models;

namespace DotNetG2E.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Hier vind u een korte beschrijving.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Onze contactpagina";

            return View();
        }

        /*public IActionResult Leerkracht_Login()
        {
            ViewData["Message"] = "De inlogpagina voor leerkrachten";

            return View("~/Views/Leerkracht/Login.cshtml");
        }*/


   /**     public IActionResult Leerling_Login()
        {
            ViewData["Message"] = "De inlogpagina voor leerlingen";
        
            return View("~/Views/Leerling");
        }*/

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //test
    }
}
