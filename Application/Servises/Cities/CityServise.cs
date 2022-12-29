using Application.Servises.Cities.Commads;
using Application.Servises.Cities.Dtos;
using Application.Servises.Files.Dtos;
using AutoMapper;
using Domain.Domain.Entities.File;
using Domain.Domain.Entities.Projects;
using Domain.Enums;
using Domain.Enums.Flies;
using Domain.Interfaces.IUnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Servises.Cities
{
    public class CityServise : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CityServise(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AddCityDto> AddAsync(AddCityCommand command)
        {
            var cityDto = new AddCityDto();

            try
            {
                var mapNews = _mapper.Map<City>(command);

                mapNews.CreationDate = DateTime.Now;

                var addNews = await _unitOfWork.City.AddCityAsync(mapNews);

                cityDto = _mapper.Map<AddCityDto>(mapNews);
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(CityServise));

                throw new Exception("erro catch");
            }

            return cityDto;
        }

        public async Task<EditCityDto> EditAsync(EditCityCommand command)
        {
            var cityDto = new EditCityDto();

            try
            {
                var getCity = await _unitOfWork.City.GetByCityIdAsync(command.Id);

                if (getCity == null)
                {
                    return null;
                }

                var mapCity = _mapper.Map(command, getCity);

                mapCity.LastUpdateDate = DateTime.Now;

                var EditCity = await _unitOfWork.City.EditCityAsync(mapCity);

                cityDto = _mapper.Map<EditCityDto>(EditCity);

            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(CityServise));

                throw new Exception("erro catch");
            }

            return cityDto;
        }

        public async Task<List<GetCityDto>> GetAllAsyncAddmin()
        {
            var cityListDto = new List<GetCityDto>();

            try
            {
                var getAllCity = await _unitOfWork.City.GetAllCityAsync();

                cityListDto = _mapper.Map<List<GetCityDto>>(getAllCity);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetAll method error", typeof(CityServise));

                throw new Exception("erro catch");
            }

            return cityListDto;
        }

        public async Task<List<GetCityDto>> GetAllAsyncWeb()
        {
            var cityListDto = new List<GetCityDto>();

            try
            {
                var getAllCity = await _unitOfWork.City.GetAllCityWebAsync();

                cityListDto = _mapper.Map<List<GetCityDto>>(getAllCity);
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetAll method error", typeof(CityServise));

                throw new Exception("erro catch");
            }

            return cityListDto;
        }

        public async Task<CityDto> GetById(long id)
        {
            var cityDto = new CityDto();

            try
            {
                var getCity = await _unitOfWork.City.GetByCityIdAsync(id);

                if (getCity == null)
                {
                    return null;
                }

                cityDto = _mapper.Map<CityDto>(getCity);

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(CityServise));

                throw new Exception("erro catch");
            }

            return cityDto;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var getCity = await _unitOfWork.City.GetByCityIdAsync(id);

                if (getCity == null)
                {
                    return false;
                }

                var deleteCity = await _unitOfWork.City.DeleteCityAsync(id);

                if (deleteCity == false)
                {
                    return false;
                }

            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(CityServise));

                throw new Exception("erro catch");
            }

            return true;
        }

        public async Task<bool> DeleTeListAsync(List<long> ids)
        {
            try
            {
                var deleteCitys = await _unitOfWork.City.DeleteListByIds(ids);

                if (deleteCitys == false)
                {
                    return false;
                }

            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(CityServise));

                throw new Exception("erro catch");
            }

            return true;
        }

       public async Task<List<SeatchCitysDto>> SerachContentAsync(string key)
        {
            var searchListCity = new List<SeatchCitysDto>();

            try
            {
                var searchNews = await _unitOfWork.City.SearchInContentAsync(key);

                searchListCity = _mapper.Map<List<SeatchCitysDto>>(searchNews);
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(CityServise));

                throw new Exception("erro catch");
            }

            return searchListCity;
        }

    }
}
