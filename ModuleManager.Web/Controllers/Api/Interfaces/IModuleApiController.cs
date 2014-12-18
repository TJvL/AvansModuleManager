﻿using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.Controllers.Api.Interfaces
{
    public interface IModuleApiController
    {
        ModuleListViewModel GetOverview(FilterAndSortingViewModel arguments);
        string ExportOverview(ExportViewModel arguments);
        Module GetOne(string key);
        bool Delete(Module entity);
        bool Edit(Module entity);
        bool Create(Module entity);  
    }
}