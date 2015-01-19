using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.ViewModels.EntityViewModel;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.Controllers.PartialViewControllers
{
    [Authorize(Roles = "Admin")]
    public class ModulesController : Controller
    {

        /*
         PK: CursusCode, Schooljaar
         */

        private readonly IUnitOfWork _unitOfWork;
        public ModulesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet, Route("Modules/Create")]
        public ActionResult Create()
        {

            var fases = _unitOfWork.GetRepository<Fase>().GetAll().ToList();
            var blokken = _unitOfWork.GetRepository<Blok>().GetAll().ToList();
            var icons = _unitOfWork.GetRepository<Icons>().GetAll().ToList();
            var onderdelen = _unitOfWork.GetRepository<Onderdeel>().GetAll().ToList();

            var module = new ModuleCrudViewModel()
            {
                Fases = fases,
                Blokken = blokken,
                Icons = icons,
                Onderdelen = onderdelen
            };

            return PartialView("~/Views/Admin/Curriculum/Module/_Add.cshtml", module);
        }

        [HttpPost, Route("Modules/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModuleCrudViewModel entity)
        {
            try {
                /* Schooljaar */
                var schooljaren = _unitOfWork.GetRepository<Schooljaar>().GetAll().ToArray();
                if (!schooljaren.Any()) return Json(new { success = false });
                var schooljaar = schooljaren.Last();

                /* Studie Punten */
                ICollection<StudiePunten> studiepuntenList = new List<StudiePunten>();
                var studiepunt1 = new StudiePunten()
                {
                    ToetsCode = entity.Toetscode1,
                    EC = entity.Ec1
                };
                studiepuntenList.Add(studiepunt1);

                if (entity.Toetscode2 != null || entity.Toetscode1 == entity.Toetscode2)
                {
                    var studiepunt2 = new StudiePunten()
                    {
                        ToetsCode = entity.Toetscode2,
                        EC = entity.Ec2
                    };
                    studiepuntenList.Add(studiepunt2);
                }

                /* Fases */
                ICollection<FaseModules> fasesList = new List<FaseModules>();
                foreach (var _fase in entity.SelectedFases)
                {
                    var faseSplitted = _fase.Split(',');

                    var faseModule = new FaseModules()
                    {
                        FaseNaam = faseSplitted[0],
                        FaseSchooljaar = faseSplitted[1],
                        OpleidingNaam = faseSplitted[2],
                        OpleidingSchooljaar = faseSplitted[3],
                        ModuleSchooljaar = schooljaar.JaarId,
                        ModuleCursusCode = entity.CursusCode,
                        Blok = entity.Blok
                    };

                    fasesList.Add(faseModule);
                }

                var module = new Module()
                {
                    Schooljaar = schooljaar.JaarId,
                    StudiePunten = studiepuntenList,
                    FaseModules = fasesList,

                    Naam = entity.Naam,
                    CursusCode = entity.CursusCode,
                    Icon = entity.Icon,
                    Status = "Nieuw",
                    Verantwoordelijke = entity.Verantwoordelijke,
                    OnderdeelCode = entity.Onderdeel
                };

                _unitOfWork.GetRepository<Module>().Create(module);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpGet, Route("Modules/Delete")]
        public ActionResult Delete(string cursusCode, string schooljaar)
        {
            if (cursusCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Module module = _unitOfWork.GetRepository<Module>().GetOne(new object[] { cursusCode, schooljaar });

            if (module == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Module/_Delete.cshtml", module);
        }

        [HttpPost, Route("Modules/Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Module entity)
        {
            try
            {
                _unitOfWork.GetRepository<Module>().Delete(entity);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }

        }


        /*
        [HttpGet, Route("Modules/Edit")]
        public ActionResult Edit(string code, string schooljaar)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var module = _unitOfWork.GetRepository<Module>().GetOne(new object[] { code, schooljaar });

            if (module == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Module/_Edit.cshtml", module);
        }

        [HttpPost, Route("Modules/Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Module entity)
        {
            try
            {
                _unitOfWork.GetRepository<Module>().Edit(entity);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpGet, Route("Modules/Delete")]
        public ActionResult Delete(string code, string schooljaar)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Module module = _unitOfWork.GetRepository<Module>().GetOne(new object[] { code, schooljaar });

            if (module == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Module/_Delete.cshtml", module);
        }

        [HttpPost, Route("Modules/Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Module entity)
        {
            try
            {
                _unitOfWork.GetRepository<Module>().Delete(entity);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }

        }*/

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}