using Application.Servises.Informaiton.Commads;
using Application.Servises.Informaiton.Dtos;
using AutoMapper;
using Domain.Domain.Entities.Information;

namespace Application.Servises.Informaiton.Mapper
{
    public class InformationMapper : Profile
    {
        public InformationMapper()
        {
            CreateMap<AddAboutUsCommand, AboutUs>();

            CreateMap<AboutUs, AddAboutUsDto>();

            CreateMap<EditAboutUsCommand, AboutUs>();

            CreateMap<AboutUs, EditAboutUsDto>();

            CreateMap<AboutUs, GetAboutUsDto>();

            CreateMap<AboutUs, AboutUsDto>();

            CreateMap<AddPersonCommand, Person>();

            CreateMap<Person, AddPersonDto>();
        }
    }
}
