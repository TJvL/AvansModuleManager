﻿using System;
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
    public class CompetentiesController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public CompetentiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet, Route("Competenties/Details")]
        public ActionResult Details(string code, string schooljaar)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var competentie = _unitOfWork.GetRepository<Competentie>().GetOne(new object[] { code, schooljaar });

            if (competentie == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Competentie/_Details.cshtml", competentie);
        }

        [HttpGet, Route("Competenties/Create")]
        public ActionResult Create()
        {
            var competentie = new Competentie();
            return PartialView("~/Views/Admin/Curriculum/Competentie/_Add.cshtml", competentie);
        }

        [HttpPost, Route("Competenties/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Competentie entity)
        {
            try
            {
                var schooljaren = _unitOfWork.GetRepository<Schooljaar>().GetAll().ToArray();
                if (!schooljaren.Any()) return Json(new { success = false });
                var schooljaar = schooljaren.Last();

                entity.Schooljaar = schooljaar.JaarId;

                _unitOfWork.GetRepository<Competentie>().Create(entity);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
        
        [HttpGet, Route("Competenties/Edit")]
        public ActionResult Edit(string code, string schooljaar)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var competentie = _unitOfWork.GetRepository<Competentie>().GetOne(new object[] { code, schooljaar });

            if (competentie == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Competentie/_Edit.cshtml", competentie);
        }

        [HttpPost, Route("Competenties/Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Competentie entity)
        {
            try
            {
                _unitOfWork.GetRepository<Competentie>().Edit(entity);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpGet, Route("Competenties/Delete")]
        public ActionResult Delete(string code, string schooljaar)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Competentie competentie = _unitOfWork.GetRepository<Competentie>().GetOne(new object[] { code, schooljaar });

            if (competentie == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Competentie/_Delete.cshtml", competentie);
        }

        [HttpPost, Route("Competenties/Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Competentie entity)
        {
            try
            {
                _unitOfWork.GetRepository<Competentie>().Delete(entity);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }

        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}