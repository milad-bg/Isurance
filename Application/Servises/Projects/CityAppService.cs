using Domain.Domain.Entities.Projects;
using Domain.Dto_s;
using Domain.Interfaces.AppService_Interfaces;
using Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Servises.Projects
{
    public class CityAppService : ICityAppService
    {
        private IUnitOfWork _unitOfWork;
        public CityAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<CityDto> GetAll()
        {
            var cities = 
            _unitOfWork.City.GetAll();
            return ToCitiesDto(cities);

            #region Local Function
            List<CityDto> ToCitiesDto(List<City> cities)
            {
                var citiesDto = new List<CityDto>();
                cities.ForEach(c => citiesDto.Add(new CityDto() {Id = c.Id,  Name = c.Name, CreationDate = c.CreationDate, LastUpdateDate = c.LastUpdateDate}));
                return citiesDto;
            }
            #endregion
        }
    }
}
