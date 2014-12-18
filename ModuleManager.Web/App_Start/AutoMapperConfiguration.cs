using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.CreateMap<Module, ModuleViewModel>();
            //AutoMapper.Mapper.CreateMap<User, UserViewModel>();
        }
    }
}