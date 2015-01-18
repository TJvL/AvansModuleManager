using System.Web.Mvc;

namespace ModuleManager.Web.Controllers
{

    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("Home/Login")]
        public ActionResult Login()
        {
            return View();
        }

    }
}