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
    public class TagsController : Controller
    {
        private readonly IGenericRepository<Tag> _tagRepository;
        public TagsController(IGenericRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public ActionResult Create()
        {
            Tag tag = new Tag();
            return PartialView("~/Views/Admin/Curriculum/Tag/_Add.cshtml", tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag entity)
        {
            var isSucces = _tagRepository.Create(entity);
            return Json(new { success = isSucces });
        }

        public ActionResult Edit(string naam)
        {
            if (naam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.GetOne(new object[] { naam });

            if (tag == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Tag/_Edit.cshtml", tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag entity)
        {
            var isSucces = _tagRepository.Edit(entity);
            return Json(new { success = isSucces });
        }

        public ActionResult Delete(string naam)
        {
            if (naam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.GetOne(new object[] { naam });

            if (tag == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Tag/_Delete.cshtml", tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Tag entity)
        {
            var isSucces = _tagRepository.Delete(entity);
            return Json(new { success = isSucces });
        }

    }
}