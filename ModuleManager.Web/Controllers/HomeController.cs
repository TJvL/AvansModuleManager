using System.Web.Mvc;

namespace ModuleManager.Web.Controllers {

    public class HomeController : Controller {
        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult Login() {
            return View();
        }

    }
}