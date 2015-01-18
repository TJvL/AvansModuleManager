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
    public class LeerlijnenController : Controller
    {
        private readonly IGenericRepository<Leerlijn> _leerlijnRepository;
        public LeerlijnenController(IGenericRepository<Leerlijn> leerlijnRepository)
        {
            _leerlijnRepository = leerlijnRepository;
        }

        public ActionResult Create()
        {
            Leerlijn leerlijn = new Leerlijn();
            return PartialView("~/Views/Admin/Curriculum/Leerlijn/_Add.cshtml", leerlijn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Leerlijn entity)
        {
            _leerlijnRepository.Create(entity);
            return Json(new { success = true });
        }

        public ActionResult Edit(string naam)
        {
            if (naam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leerlijn leerlijn = _leerlijnRepository.GetOne(new object[] { naam });

            if (leerlijn == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Leerlijn/_Edit.cshtml", leerlijn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Leerlijn entity)
        {
            _leerlijnRepository.Edit(entity);
            return Json(new { success = true });
        }

        public ActionResult Delete(string naam)
        {
            if (naam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leerlijn leerlijn = _leerlijnRepository.GetOne(new object[] { naam });

            if (leerlijn == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Leerlijn/_Delete.cshtml", leerlijn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Leerlijn entity)
        {
            _leerlijnRepository.Delete(entity);
            return Json(new { success = true });
        }

    }
}