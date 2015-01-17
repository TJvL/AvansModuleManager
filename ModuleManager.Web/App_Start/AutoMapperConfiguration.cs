using System.Linq;
using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;
using AutoMapper;
using ModuleManager.UserDAL;

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

<<<<<<< HEAD
            Mapper.CreateMap<Module, ModuleTabelViewModel>()
                //.ForMember(dest => dest.Onderdeel, opt => opt.MapFrom(
                //    src => src.OnderdeelCode)) // TODO:
                .ForMember(dest => dest.Cursuscode, opt => opt.MapFrom(
                    src => src.CursusCode)) // TODO:
                .ForMember(dest => dest.Omschrijving, opt => opt.MapFrom(
                    src => src.Beschrijving)) // TODO:
                //.ForMember(dest => dest.Werkvormen, opt => opt.MapFrom(
                //    src => string.Join(Delimiter, src.ModuleWerkvorm.Select(inSrc => inSrc.WerkvormType))))
                .ForMember(dest => dest.Studiepunten, opt => opt.Ignore());

            //AutoMapper.Mapper.CreateMap<User, UserViewModel>();
=======
            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(
                    src => src.naam))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(
                    src => src.email))
                .ForMember(dest => dest.GebruikersNaam, opt => opt.MapFrom(
                    src => src.UserNaam));
>>>>>>> origin/master_development
        }
    }
}