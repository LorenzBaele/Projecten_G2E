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
		private readonly ILeerkrachtRepository _leerkrachtRepository;
		private readonly ISessieRepository _sessieRepository;


		public LeerkrachtController(ILeerkrachtRepository leerkrachtRepository, ISessieRepository sessieRepository)
		{
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

		public IActionResult Sessie(int id)
        {
            return Content(id.ToString());
        }
    }
}