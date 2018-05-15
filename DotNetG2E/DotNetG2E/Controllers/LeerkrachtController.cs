﻿using System;
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

        [HttpGet]
        public IActionResult Sessie(int id)
        {

            //untill db error is fixed
            Pupil p1 = new Pupil() { Name = "Wannes" };
            ICollection<Pupil> pList1 = new List<Pupil>();
            pList1.Add(p1);
            Sessie sessie = _sessieRepository.GetBy(id);
            sessie.Groups.Add(new Group() { Name = "2B", Pupils = pList1 , Selected = false});
            ViewBag.sessie = sessie;
            //-----

            ViewBag.sessie = _sessieRepository.GetBy(id);

            return View();
        }

        
        public IActionResult ActiveerSessie(int id)
        {
            Sessie sessie = _sessieRepository.GetBy(id);
            sessie.IsActive = true;
            Pupil p1 = new Pupil() { Name = "Wannes" };
            ICollection<Pupil> pList1 = new List<Pupil>();
            pList1.Add(p1);
            sessie.Groups.Add(new Group() { Name = "2B", Pupils = pList1, Selected = false });
            ViewBag.sessie = sessie;
            //-----
            _sessieRepository.SaveChanges();
            ViewBag.sessie = _sessieRepository.GetBy(id);
            return View("~/Views/Leerkracht/Sessie.cshtml");
        }

        public IActionResult DeactiveerSessie(int id)
        {
            Sessie sessie = _sessieRepository.GetBy(id);
            sessie.IsActive = false;
            Pupil p1 = new Pupil() { Name = "Wannes" };
            ICollection<Pupil> pList1 = new List<Pupil>();
            pList1.Add(p1);
            sessie.Groups.Add(new Group() { Name = "2B", Pupils = pList1, Selected = false });
            ViewBag.sessie = sessie;
            //-----
            _sessieRepository.SaveChanges();
            ViewBag.sessie = _sessieRepository.GetBy(id);
            return View("~/Views/Leerkracht/Sessie.cshtml");
        }
    }
}