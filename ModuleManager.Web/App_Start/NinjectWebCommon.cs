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
using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.BusinessLogic.Services;
using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.DomainDAL.Repositories.Dummies;

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
            kernel.Bind<IGenericRepository<Competentie>>().To<CompetentieRepository>();
            kernel.Bind<IGenericRepository<Fase>>().To<FaseRepository>();
            kernel.Bind<IGenericRepository<Leerlijn>>().To<LeerlijnRepository>();
            kernel.Bind<IGenericRepository<Module>>().To<ModuleRepository>();
            kernel.Bind<IGenericRepository<Tag>>().To<TagRepository>();
            kernel.Bind<IGenericRepository<Blok>>().To<BlokRepository>();
            kernel.Bind<IGenericRepository<Niveau>>().To<NiveauRepository>();
            kernel.Bind<IGenericRepository<Schooljaar>>().To<SchooljaarRepository>();
            kernel.Bind<IGenericRepository<Status>>().To<StatusRepository>();
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
