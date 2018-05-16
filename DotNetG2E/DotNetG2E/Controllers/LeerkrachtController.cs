using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Data.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotNetG2E.Models.Domain;
using DotNetG2E.Models.SessieViewModels;

namespace DotNetG2E.Controllers
{
    [Authorize(Policy = "Leerkracht")]
    [ServiceFilter(typeof(LeerkrachtFilter))]
    public class LeerkrachtController : Controller
    {
        private string filter;
        private int filterActive;
        private readonly ILeerkrachtRepository _leerkrachtRepository;
        private readonly ISessieRepository _sessieRepository;
        //test
        private Sessie _selectedSession;


        public LeerkrachtController(ILeerkrachtRepository leerkrachtRepository, ISessieRepository sessieRepository)
        {
            filter = "";
            filterActive = 2;
            _leerkrachtRepository = leerkrachtRepository;
            _sessieRepository = sessieRepository;
        }

        [HttpGet]
        public IActionResult Index(Leerkracht leerkracht)
        {
            ViewData["Message"] = "De overzichtpagina voor leerkrachten";

            //return View();
            //IndexViewModel vm = new IndexViewModel()
            //{
            //	Sessions = leerkracht.GetSessies().Select(t=> new SessieViewModel(t))
            //};

            if (filterActive == 1)
            {
                return View(_sessieRepository.GetByFilter(filter));
            }
            else if (filterActive == 2)
            {
                return View(_sessieRepository.GetByFilterActive(filter));
            }
            else
            {
                return View(_sessieRepository.GetByFilterNotActive(filter));

            }

        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            filterActive = id;
            return View();

        }
        [HttpPost]
        public IActionResult Index(String sessionSearch)
        {
            ViewData["Message"] = "De overzichtpagina voor leerkrachten";

            filter = sessionSearch;

            return View();


        }

        [HttpGet]
        public IActionResult Sessie(int id)
        {
            _selectedSession = _sessieRepository.GetBy(id);
            ViewBag.Sessie = _sessieRepository.GetBy(id);
            ViewBag.Groups = _sessieRepository.GetBy(id).Groups;


            return View();
        }

        
        public IActionResult ActiveerSessie(int id)
        {
            Sessie sessie = _sessieRepository.GetBy(id);
            ViewBag.sessie = sessie;
            _sessieRepository.SaveChanges();
            ViewBag.sessie = _sessieRepository.GetBy(id);
            return View("~/Views/Leerkracht/Sessie.cshtml");
        }

        public IActionResult DeactiveerSessie(int id)
        {
            Sessie sessie = _sessieRepository.GetBy(id);
            sessie.IsActive = false;         
            ViewBag.sessie = sessie;
            _sessieRepository.SaveChanges();
            ViewBag.sessie = _sessieRepository.GetBy(id);
            return View("~/Views/Leerkracht/Sessie.cshtml");
        }

        public IActionResult DeactiveerGroep(int id, int sessieId)
        {
            Sessie sessie = _sessieRepository.GetBy(sessieId);
            Group group = sessie.Groups.ToList().Find(e => e.GroupId == id);
            group.Selected = false;
            _sessieRepository.SaveChanges();
            ViewBag.sessie = sessie;

            return View("Sessie");
            
        }
    }
}