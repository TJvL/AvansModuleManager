using System.Linq;
using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;
using AutoMapper;

namespace ModuleManager.Web
{
    public static class AutoMapperConfiguration
    {
        const string Delimiter = ", ";
        public static void Configure()
        {
            Mapper.CreateMap<Module, ModuleViewModel>()
                .ForMember(dest => dest.TotalEc, opt => opt.MapFrom(
                    src => src.StudiePunten
                        .Select(sp => sp.EC).Sum()))
                .ForMember(dest => dest.FaseNamen, opt => opt.MapFrom(
                    src => (string.Join(Delimiter, src.FaseModules.Select(inSrc => inSrc.FaseNaam)))))
                .ForMember(dest => dest.Blokken, opt => opt.MapFrom(
                    src => (string.Join(Delimiter, src.FaseModules.Select(inSrc => inSrc.Blok).Distinct()))))
                .ForMember(dest => dest.Docenten, opt => opt.MapFrom(
                    src => string.Join(Delimiter, src.Docent.Select(inSrc => inSrc.Name))));

            //AutoMapper.Mapper.CreateMap<User, UserViewModel>();
        }
    }
}