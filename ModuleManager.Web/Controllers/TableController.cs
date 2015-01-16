using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.ViewModels;
using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.Controllers
{
    public class TableController : Controller
    {
        private IGenericRepository<Module> _moduleRepository;
        private IGenericRepository<Fase> _faseRepository;

        public TableController(IGenericRepository<Module> moduleRepository, IGenericRepository<Fase> faseRepository)
        {
            _moduleRepository = moduleRepository;
            _faseRepository = faseRepository;
        }

        // GET: Table
        public ActionResult Index()
        {
            var modules = _moduleRepository.GetAll();
            var moduletables = modules.Select(src => Mapper.Map<Module, ModuleTabelViewModel>(src));


            var view = new LessenTabelViewModel();
            return View(view);
        }
    }
}