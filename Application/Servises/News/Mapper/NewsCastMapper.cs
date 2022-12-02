using Application.Servises.News.Commads;
using Application.Servises.News.Dtos;
using AutoMapper;
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

            CreateMap<NewsCast, NewsCastDto>();
        }
    }
}
