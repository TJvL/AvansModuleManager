using System;
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
    public class TagsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public TagsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet, Route("Tags/Create")]
        public ActionResult Create()
        {
            var tag = new Tag();
            return PartialView("~/Views/Admin/Curriculum/Tag/_Add.cshtml", tag);
        }

        [HttpPost, Route("Tags/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag entity)
        {
            try
            {
                var schooljaren = _unitOfWork.GetRepository<Schooljaar>().GetAll().ToArray();
                if (!schooljaren.Any())
                    return Json(new { success = false });
                var schooljaar = schooljaren.Last();

                entity.Schooljaar = schooljaar.JaarId;

                var value = _unitOfWork.GetRepository<Tag>().Create(entity);
                return value != null ? Json(new { success = false, strError = value }) : Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpGet, Route("Tags/Delete")]
        public ActionResult Delete(string naam, string schooljaar)
        {
            if (naam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tag tag = _unitOfWork.GetRepository<Tag>().GetOne(new object[] { naam, schooljaar });

            if (tag == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Admin/Curriculum/Tag/_Delete.cshtml", tag);
        }

        [HttpPost, Route("Tags/Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Tag entity)
        {
            try
            {
                _unitOfWork.GetRepository<Tag>().Delete(entity);
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