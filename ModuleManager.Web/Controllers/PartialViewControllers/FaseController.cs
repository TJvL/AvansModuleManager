using AutoMapper;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.DomainDAL.Repositories;
using ModuleManager.UserDAL;
using ModuleManager.Web.ViewModels;
using ModuleManager.Web.ViewModels.PartialViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ModuleManager.Web.Controllers.Api
{
    public class FasesController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public FasesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet, Route("Fases/Create")]
        public ActionResult Create()
        {
            var fase = new FaseCrudViewModel()
            {
                FaseTypes = _unitOfWork.GetRepository<FaseType>().GetAll().ToList()
            };

            //var schooljaren = _unitOfWork.GetRepository<Schooljaar>().GetAll().ToArray();

            return PartialView("~/Views/Admin/Curriculum/Fase/_Add.cshtml", fase);
        }

        [HttpPost, Route("Fases/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fase entity)
        {
            var schooljaren = _unitOfWork.GetRepository<Schooljaar>().GetAll().ToArray();

            if (schooljaren.Any()) return Json(new {success = false});
            var schooljaar = schooljaren.Last();

            entity.Schooljaar = schooljaar.JaarId;

            _unitOfWork.GetRepository<Fase>().Create(entity);
            return Json(new { success = true });
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fase entity)
        {
            _faseRepository.Create(entity);
            return Json(new { success = true });
        }

        public ActionResult Edit(string naam, string schooljaar, string opleidingsNaam, string opleidingsSchooljaar)
        {
            if (naam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fase fase = _faseRepository.GetOne(new object[] { naam, schooljaar, opleidingsNaam, opleidingsSchooljaar });

            if (fase == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Fase/_Edit.cshtml", fase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fase entity)
        {
            _faseRepository.Edit(entity);
            return Json(new { success = true });
        }

        public ActionResult Delete(string naam, string schooljaar, string opleidingsNaam, string opleidingsSchooljaar)
        {
            if (naam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fase fase = _faseRepository.GetOne(new object[] { naam, schooljaar, opleidingsNaam, opleidingsSchooljaar });

            if (fase == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Fase/_Delete.cshtml", fase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Fase entity)
        {
            _faseRepository.Delete(entity);
            return Json(new { success = true });
        }*/

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}