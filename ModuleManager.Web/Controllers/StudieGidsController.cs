﻿using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.ViewModels;
using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;
using System.Collections.Generic;

namespace ModuleManager.Web.Controllers
{
    public class StudieGidsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudieGidsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Table
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new StudiegidsViewModel();

            foreach (var ft in _unitOfWork.GetRepository<FaseType>().GetAll()) // Geen Jaar
            {
                var maxSchooljaar = _unitOfWork.GetRepository<Schooljaar>().GetAll().Max(src => src.JaarId);
                var tabellenlijst = new LessenTabelViewModel { FaseType = ft.Type };
                var fasems = _unitOfWork.GetRepository<FaseModules>().GetAll()
                    .Where(src => src.FaseSchooljaar.Equals(maxSchooljaar))
                    //.Where(src => src.ModuleSchooljaar.Equals(maxSchooljaar)) // Onnodig ???
                    //.Where(src => src.OpleidingSchooljaar.Equals(maxSchooljaar)) // Onnodig ???
                    .ToList(); // FaseSchooljaar, ModuleSchooljaar, OpleidingSchooljaar
                var fases = _unitOfWork.GetRepository<Fase>().GetAll()
                    .Where(src => src.Schooljaar.Equals(maxSchooljaar))
                   // .Where(src => src.OpleidingSchooljaar.Equals(maxSchooljaar)) // Onnodig ???
                    .ToList(); // Schooljaar, OpleidingSchooljaar
                //return CollectionA
                //  .Join(CollectionB,
                //      a => new { a.KeyA, a.KeyB },
                //      b => new { b.KeyA, b.KeyB },
                //      (a, b) => new { a, b })
                var joined = fasems
                    .Join(fases,
                        a => new { fnaam = a.FaseNaam, fschooljaar = a.FaseSchooljaar, onaam = a.OpleidingNaam, oschooljaar = a.OpleidingSchooljaar },
                        b => new { fnaam = b.Naam, fschooljaar = b.Schooljaar, onaam = b.OpleidingNaam, oschooljaar = b.OpleidingSchooljaar },
                        (a, b) => new { a, b }).ToList();
                foreach (var random in joined.Where(src => src.b.FaseType.Equals(tabellenlijst.FaseType)).DistinctBy(src => new { src.a.Blok, src.a.FaseNaam })) // fasemodule collectie WHERE fasetype.EQUALS(ft.Type)
                {
                    var tabel = new LesTabelViewModel { Blok = random.a.Blok, FaseNaam = random.a.FaseNaam };
                    var rows = new List<ModuleTabelViewModel>();
                    //foreach (var fm2 in _unitOfWork.GetRepository<FaseModules>().GetAll() // Schooljaar, ModuleSchooljaar, OpleidingSchooljaar
                    //    .Where(src => src.Blok.Equals(tabel.Blok))
                    //    .Where(src => src.FaseNaam.Equals(tabel.FaseNaam))) // WTF DOE IK HIER?!
                    foreach (var fm2 in joined
                        .Where(src => src.a.Blok.Equals(tabel.Blok))
                        .Where(src => src.a.FaseNaam.Equals(tabel.FaseNaam)))
                    {
                        var module = _unitOfWork.GetRepository<Module>().GetOne(new object[] { fm2.a.ModuleCursusCode, fm2.a.ModuleSchooljaar }); //
                        var row = Mapper.Map<Module, ModuleTabelViewModel>(module);
                        rows.Add(row);
                    }
                    var orderedRows = rows.OrderBy(src => src.Onderdeel).ToList();
                    var uniqueOnderdelen = orderedRows.Select(src => src.Onderdeel).Distinct();
                    foreach (var onderdeel in uniqueOnderdelen)
                    {
                        tabel.Onderdelen.Add(new OnderdeelTabelViewModel { Onderdeel = onderdeel });
                    }
                    foreach (var module in orderedRows)
                    {
                        OnderdeelTabelViewModel onderdeelTabelViewModel = tabel.Onderdelen.FirstOrDefault(src => src.Onderdeel.Equals(module.Onderdeel));
                        if (onderdeelTabelViewModel != null)
                            onderdeelTabelViewModel.Modules.Add(module);
                    }
                    tabellenlijst.Tabellen.Add(tabel);
                }
                vm.Opleidingsfasen.Add(tabellenlijst);
                vm.Opleidingsfasen = vm.Opleidingsfasen.OrderBy(src => src.FaseType).ToList();
                var last = vm.Opleidingsfasen.LastOrDefault();
                vm.Opleidingsfasen.Remove(last);
                vm.Opleidingsfasen.Insert(0, last);
            }

            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}