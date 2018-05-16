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
            if (sessie.IsActive)
            {
                Pupil p1 = new Pupil() { Name = "Wannes" };
                ICollection<Pupil> pList1 = new List<Pupil>();
                pList1.Add(p1);
                Pupil p2 = new Pupil() { Name = "Arne" };
                ICollection<Pupil> pList2 = new List<Pupil>();
                pList2.Add(p2);
                sessie.Groups.Add(new Group() { Name = "2B", Pupils = pList1, Selected = false });
                sessie.Groups.Add(new Group() { Name = "2B", Pupils = pList2, Selected = true });
                ViewBag.Sessie = sessie;
                return View("Selection");
            }
            return View();
            
        }

        public IActionResult WaitScreen(int id)
        {
            return View("WaitScreen");
        }

        public IActionResult Exercise()
        {
            return View("Exercise");
        }

    }
}