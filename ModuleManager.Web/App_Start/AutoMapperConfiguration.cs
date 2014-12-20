using System.Linq;
using Microsoft.Ajax.Utilities;
using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.CreateMap<Module, ModuleViewModel>()
                .ForMember(dest => dest.TotalEc, opt => opt.MapFrom(
                    src => src.StudiePunten
                        .Select(sp => sp.EC).Sum()))
                .ForMember(dest => dest.FaseModules, opt => opt.MapFrom(src => src.FaseModules))
                .ForMember(dest => dest.Blok, opt => opt.MapFrom(
                    src => src.FaseModules
                        .DistinctBy(fasemodule => fasemodule.Blok)
                        .Select(fasemodule => fasemodule.Blok)));
            //AutoMapper.Mapper.CreateMap<User, UserViewModel>();
        }
    }
}