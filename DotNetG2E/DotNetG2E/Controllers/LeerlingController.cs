using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using DotNetG2E.Data.Repositories;

namespace DotNetG2E.Controllers
{
    public class LeerlingController : Controller
    {
        private readonly ISessieRepository _sessieRepository;

        public LeerlingController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = "De overzichtpagine voor leerlingen";

            return View();
        }

        [HttpPost]
        public IActionResult Index(string leerlingCode)
        {
            Sessie sessie = _sessieRepository.GetBy(Convert.ToInt16(leerlingCode));
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