using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetG2E.Controllers
{
    public class LeerlingController : Controller
    {
        //private readonly ISessieRepository _sessieRepository;
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = "De overzichtpagine voor leerlingen";

            return View();
        }

        [HttpPost]
        public IActionResult Index(string leerlingCode)
        {
            //Sessie sessie = _sessieRepository.getBy(int.TryParse(leerlingCode));
            return View("Selection");
        }

        public IActionResult WaitScreen()
        {
            return View("WaitScreen");
        }

        public IActionResult Exercise()
        {
            return View("Exercise");
        }

    }
}