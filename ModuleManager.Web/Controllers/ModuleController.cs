using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuleManager.Web.Controllers
{

    public class ModuleController : Controller
    {
        [HttpGet]
        public ActionResult Overview()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Overview_Teacher_Temp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details_Teacher_Temp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

    }
}