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
    public class LeerkrachtController : Controller
    {
		private readonly ILeerkrachtRepository _leerkrachtRepository;
		private readonly ISessieRepository _sessieRepository;
		//[Authorize(Policy = "Leerkracht")]
		//[ServiceFilter(typeof(LeerkrachtFilter))]
		public LeerkrachtController(ILeerkrachtRepository leerkrachtRepository, ISessieRepository sessieRepository)
		{
			_leerkrachtRepository = leerkrachtRepository;
			_sessieRepository = sessieRepository;
		}

		public IActionResult Index(Leerkracht leerkracht)
        {
			ViewData["Message"] = "De overzichtpagine voor leerkrachten";

            //return View();
            //IndexViewModel vm = new IndexViewModel()
            //{
            //	Sessions = leerkracht.GetSessies().Select(t=> new SessieViewModel(t))
            //};

            ViewData["Sessies"] = _sessieRepository.GetAll();
            return View(_sessieRepository.GetAll());

        }

        public IActionResult Select_Sessie(Sessie sessie)
        {
			
            ViewData["Message"] = "Overzichtspagina van een sessie";

            return View("~/Views/Leerkracht/Sessie.cshtml");
        }

		public IActionResult Select_Sessie2(Sessie sessie)
		{

			ViewData["Message"] = "Overzichtspagina van een sessie";

			return View("~/Views/Leerkracht/Sessie2.cshtml");
		}

		public IActionResult Sessie(string name)
        {
            return Content($"{name}");
        }
    }
}