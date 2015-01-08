using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.DomainDAL.Repositories;
using ModuleManager.DomainDAL.UnitOfWork;
using ModuleManager.Web.App_Start;
using ModuleManager.Web.Controllers.Api;
using ModuleManager.Web.Controllers.Api.Interfaces;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;
using ModuleManager.BusinessLogic.Services;
using ModuleManager.BusinessLogic.Interfaces.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace ModuleManager.Web.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Domain entity repositories:
            kernel.Bind<IGenericRepository<Competentie>>().To<DummyCompetentieRepository>();
            kernel.Bind<IGenericRepository<Fase>>().To<DummyFaseRepository>();
            kernel.Bind<IGenericRepository<Leerlijn>>().To<DummyLeerlijnRepository>();
            kernel.Bind<IGenericRepository<Module>>().To<DummyModuleRepository>();
            kernel.Bind<IGenericRepository<Tag>>().To<DummyTagRepository>();
            kernel.Bind<IGenericRepository<Blok>>().To<DummyBlokRepository>();
            kernel.Bind<IGenericRepository<Niveau>>().To<DummyNiveauRepository>();
            kernel.Bind<IGenericRepository<Schooljaar>>().To<DummySchooljaarRepository>();
            kernel.Bind<IGenericRepository<Status>>().To<DummyStatusRepository>();
            // UnitOfWork session for repositories to use:
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            // Domain entity API controllers:
            kernel.Bind<IGenericApiController<Competentie>>().To<CompetentieController>();
            kernel.Bind<IGenericApiController<Fase>>().To<FaseController>();
            kernel.Bind<IGenericApiController<Leerlijn>>().To<LeerlijnController>();
            kernel.Bind<IGenericApiController<Tag>>().To<TagController>();
            kernel.Bind<IModuleApiController>().To<ModuleController>();

            // Filter-, Sorter- and Export-services:
            kernel.Bind<IFilterSorterService<Module>>().To<ModuleFilterSorterService>();

        }        
    }
}
