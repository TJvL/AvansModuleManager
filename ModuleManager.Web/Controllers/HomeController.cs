using System.Web.Mvc;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Repositories;

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


        public ActionResult Yolo()
        {
            var repo = new GenericRepo();

            var test = repo.GetAll<Fase>();

            var testnormaal = repo.GetAllNormaal();
            var testinclude = repo.GetAllInclude();
            var testincludeMulti = repo.GetAllIncludeMultiple();

            return View();
        }

    }
}