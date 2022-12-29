using Application.Servises.Files.Dtos;
using Application.Servises.News.Commads;
using Application.Servises.News.Dtos;
using AutoMapper;
using Domain.Domain.Entities.File;
using Domain.Domain.Entities.Projects;
using Microsoft.VisualBasic.CompilerServices;

namespace application.servises.Projects.mapper
{
    public class Projectmapper : Profile
    {
        public Projectmapper()
        {
            CreateMap<AddProjectCommand, Project>();

            CreateMap<Project, AddProjectDto>();

            CreateMap<EditProjectCommand, Project>();

            CreateMap<Project, EditProjectDto>();

            CreateMap<Project, GetProjectDto>()
                 .ForMember(destination => destination.CityTitle, option => option.MapFrom(source => source.City.Title))
                 .ForMember(destination => destination.CityId, option => option.MapFrom(source => source.City.Id));

            CreateMap<Project, ProjectDto>()
                 .ForMember(destination => destination.CityTitle, option => option.MapFrom(source => source.City.Title))
                 .ForMember(destination => destination.CityId, option => option.MapFrom(source => source.City.Id));


            CreateMap<MediaEntity, MediasDto>()
                .ForMember(destination => destination.Url, option => option.MapFrom(source => "https://plansbox.ir/" + source.Media.Url))
                .ForMember(destination => destination.Id, option => option.MapFrom(source => source.Media.Id));
        }
    }
}
