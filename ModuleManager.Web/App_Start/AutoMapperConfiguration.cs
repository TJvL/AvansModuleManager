﻿using System.Linq;
using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.EntityViewModel;
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
            Mapper.CreateMap<Module, ModuleViewModel>();
                //.ForMember(dest => dest.StudiePunten, opt => opt.MapFrom(
                //    src => src.StudiePunten))
                //.ForMember(dest => dest.ModuleCompetentie, opt => opt.MapFrom(
                //    src => src.ModuleCompetentie));

            Mapper.CreateMap<ModuleCompetentie, ModuleCompetentieViewModel>();
                //.ForMember(dest => dest.Competentie, opt => opt.MapFrom(
                //    src => src.Competentie));

            Mapper.CreateMap<Competentie, CompetentieViewModel>();

            Mapper.CreateMap<StudiePunten, StudiePuntenViewModel>();

            Mapper.CreateMap<FaseModules, FaseModulesViewModel>();

            Mapper.CreateMap<StudieBelasting, StudieBelastingViewModel>();

            Mapper.CreateMap<ModuleWerkvorm, ModuleWerkvormViewModel>();

            Mapper.CreateMap<Weekplanning, WeekplanningViewModel>();

            Mapper.CreateMap<Beoordelingen, BeoordelingenViewModel>();

            Mapper.CreateMap<Leermiddelen, LeermiddelenViewModel>();

            Mapper.CreateMap<Leerdoelen, LeerdoelenViewModel>();

            Mapper.CreateMap<Docent, DocentViewModel>();

            Mapper.CreateMap<Leerlijn, LeerlijnViewModel>();

            Mapper.CreateMap<Tag, TagViewModel>();

            Mapper.CreateMap<Module, ModuleVoorkennisViewModel>();

            Mapper.CreateMap<Module, ModulePartialViewModel>()
                .ForMember(dest => dest.TotalEc, opt => opt.MapFrom(
                    src => src.StudiePunten
                        .Select(sp => sp.EC).Sum()))
                .ForMember(dest => dest.FaseNamen, opt => opt.MapFrom(
                    src => (string.Join(Delimiter, src.FaseModules.Select(inSrc => inSrc.FaseNaam)))))
                .ForMember(dest => dest.Blokken, opt => opt.MapFrom(
                    src => (string.Join(Delimiter, src.FaseModules.Select(inSrc => inSrc.Blok).Distinct()))))
                .ForMember(dest => dest.Docenten, opt => opt.MapFrom(
                    src => string.Join(Delimiter, src.Docent.Select(inSrc => inSrc.Name))));

            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(
                    src => src.naam))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(
                    src => src.email))
                .ForMember(dest => dest.GebruikersNaam, opt => opt.MapFrom(
                    src => src.UserNaam));
        }
    }
}