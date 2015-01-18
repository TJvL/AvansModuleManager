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
    public class CompetentiesController : Controller
    {
        private readonly IGenericRepository<Competentie> _competentieRepository;
        public CompetentiesController(IGenericRepository<Competentie> competentieRepository)
        {
            _competentieRepository = competentieRepository;
        }

        public ActionResult Details(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competentie competentie = _competentieRepository.GetOne(new object[] { code });

            if (competentie == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Competentie/_Details.cshtml", competentie);
        }

        public ActionResult Create()
        {
            Competentie competentie = new Competentie();
            return PartialView("~/Views/Admin/Curriculum/Competentie/_Add.cshtml", competentie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Competentie entity)
        {
            _competentieRepository.Create(entity);
            return Json(new { success = true });
        }

        public ActionResult Edit(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competentie competentie = _competentieRepository.GetOne(new object[] { code });

            if (competentie == null)
            {
                return HttpNotFound();
            }
            
            return PartialView("~/Views/Admin/Curriculum/Competentie/_Edit.cshtml", competentie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Competentie entity)
        {
            _competentieRepository.Edit(entity);
            return Json(new { success = true });
        }

        public ActionResult Delete(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competentie competentie = _competentieRepository.GetOne(new object[] { code });

            if (competentie == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Competentie/_Delete.cshtml", competentie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Competentie entity)
        {
            _competentieRepository.Delete(entity);
            return Json(new { success = true });
        }
        
    }
}