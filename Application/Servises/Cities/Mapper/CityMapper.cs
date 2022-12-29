using Application.Servises.Cities.Commads;
using Application.Servises.Cities.Dtos;
using AutoMapper;
using Domain.Domain.Entities.Projects;

namespace Application.Servises.Cities.Mapper
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<AddCityCommand, City>();

            CreateMap<City, AddCityDto>();

            CreateMap<EditCityCommand, City>();

            CreateMap<City, EditCityDto>();

            CreateMap<City, GetCityDto>();

            CreateMap<City, CityDto>();
        }
    }
}
