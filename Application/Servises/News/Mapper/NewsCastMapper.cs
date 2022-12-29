using Application.Servises.Files.Dtos;
using Application.Servises.News.Commads;
using Application.Servises.News.Dtos;
using AutoMapper;
using Domain.Domain.Entities.File;
using Domain.Domain.Entities.News;

namespace Application.Servises.News.Mapper
{
    public class NewsCastMapper : Profile
    {
        public NewsCastMapper()
        {
            CreateMap<AddNewsCastCommand, NewsCast>();

            CreateMap<NewsCast, AddNewsCastDto>();

            CreateMap<EditNewsCastCommand, NewsCast>();

            CreateMap<NewsCast, EditNewsCastDto>();

            CreateMap<NewsCast, GetNewsCastDto>();

            CreateMap<NewsCast, NewsCastDto>();

            CreateMap<MediaEntity, MediasDto>() 
                .ForMember(destination => destination.Url, option => option.MapFrom(source => "https://plansbox.ir/" + source.Media.Url))
                .ForMember(destination => destination.Id, option => option.MapFrom(source => source.Media.Id));
        }
    }
}
