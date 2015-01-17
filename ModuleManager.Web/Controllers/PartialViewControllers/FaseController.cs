using AutoMapper;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
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
        private readonly IGenericRepository<Fase> _faseRepository;
        public FasesController(IGenericRepository<Fase> faseRepository)
        {
            _faseRepository = faseRepository;
        }

        public ActionResult Create()
        {
            Fase fase = new Fase();
            return PartialView("~/Views/Admin/Curriculum/Fase/_Add.cshtml", fase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fase entity)
        {
            var isSucces = _faseRepository.Create(entity);
            return Json(new { success = isSucces });
        }

        public ActionResult Edit(string naam)
        {
            if (naam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fase fase = _faseRepository.GetOne(new object[] { naam });

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
            var isSucces = _faseRepository.Edit(entity);
            return Json(new { success = isSucces });
        }

        public ActionResult Delete(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fase fase = _faseRepository.GetOne(new object[] { code });

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
            var isSucces = _faseRepository.Delete(entity);
            return Json(new { success = isSucces });
        }

    }
}