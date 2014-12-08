using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuleManager.Web.Controllers
{

    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Management()
        {
            //Overview page
            return View();
        }

        [HttpGet]
        public ActionResult Curriculum()
        {
            //Toevoegen/verwijderen/bewerken van leerijnen, tags en competenties doormiddel van pop-up??
            //Toevoegen van Module is aparte POST
            return View();
        }
        [HttpGet]
        public ActionResult CheckModules()
        {
            //herinneringen sturen doormiddel van pop-up/api??
            return View();
        }

        [HttpGet]
        public ActionResult AddModule()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddModule()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserManagement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserManagement()
        {
            //Delete, Edit Or Create
            return View();
        }

        [HttpGet]
        public ActionResult Archive()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Archive()
        {
            return View();
        }
    }
}