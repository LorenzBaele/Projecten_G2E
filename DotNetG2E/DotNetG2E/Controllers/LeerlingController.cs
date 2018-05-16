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
            ViewData["Message"] = "De overzichtpagina voor leerlingen";

            return View();
        }

        [HttpPost]
        public IActionResult Index(int leerlingCode)
        {

            Sessie sessie = _sessieRepository.GetBy(leerlingCode);


            if (sessie != null)
            {
                if (sessie.IsActive)
                {

                    ViewBag.Sessie = sessie;
                    return View("Selection");
                }
                else
                {
                    ViewBag.NotActive = true;
                    return View();
                }
            }
            else
            {
                ViewBag.NotFound = true;
                return View();
            }

        }

        public IActionResult WaitScreen(int id, int sessieId)
        {


            Sessie sessie = _sessieRepository.GetBy(sessieId);
            Console.WriteLine("break point");
            Boolean allGroupsReady = true;

            foreach (var groep in sessie.Groups)
            {
                if (!groep.Selected)
                {
                    allGroupsReady = false;
                }
            }

            if (allGroupsReady)
            {
                return RedirectToAction("Exercise", "Leerling");
            }
            else
            {
				ViewBag.Sessie = sessie;
				Group group = sessie.Groups.ToList().Find(e => e.GroupId == id);
                group.Selected = true;
                Console.WriteLine("break point");
                _sessieRepository.SaveChanges();
                return View("WaitScreen");
            }



        }

        public IActionResult Exercise()
        {
            return View("Exercise");
        }



    }
}