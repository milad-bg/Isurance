using Application.Servises.Informaiton.Commads;
using Application.Servises.Informaiton.Dtos;
using AutoMapper;
using Domain.Domain.Entities.File;
using Domain.Domain.Entities.Information;
using Domain.Enums;
using Domain.Enums.Flies;
using Domain.Interfaces.IUnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Servises.Informaiton
{
    public class AboutUsServise : IAboutUsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public AboutUsServise(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AddAboutUsDto> AddAsync(AddAboutUsCommand command)
        {
            var aboutUsDto = new AddAboutUsDto();

            try
            {
                var mapNews = _mapper.Map<AboutUs>(command);

                mapNews.CreationDate = DateTime.Now;

                var addNews = await _unitOfWork.AboutUs.AddAboutUsAsync(mapNews);

                var mediaEntity = new List<MediaEntity>();

                for (int i = 0; i < addNews.Persons.Count(); i++)
                {
                    if (command.Persons[i].CoverMediaId != 0)
                    {
                        var AddmediaCover = AddMediaInDataBase(command.Persons[i].CoverMediaId, addNews.Persons.ToList()[i], MediaEntityType.CoverImage);

                        mediaEntity.Add(AddmediaCover);
                    }
                }

                var addMedias = false;

                if (mediaEntity.Any())
                {
                    addMedias = await _unitOfWork.Media.AddRangeAsync(mediaEntity);
                }

                aboutUsDto = _mapper.Map<AddAboutUsDto>(mapNews);
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(AboutUsServise));

                throw new Exception("erro catch");
            }

            return aboutUsDto;
        }

        public async Task<EditAboutUsDto> EditAsync(EditAboutUsCommand command)
        {
            var aboutUsDto = new EditAboutUsDto();

            try
            {
                var getAboutUs = await _unitOfWork.AboutUs.GetByAboutUsIdAsync(command.Id);

                if (getAboutUs == null)
                {
                    return null;
                }

                var mapAboutUs = _mapper.Map(command, getAboutUs);

                mapAboutUs.LastUpdateDate = DateTime.Now;

                var EditAboutUs = await _unitOfWork.AboutUs.EditAboutUsAsync(mapAboutUs);

                aboutUsDto = _mapper.Map<EditAboutUsDto>(EditAboutUs);

            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(AboutUsServise));

                throw new Exception("erro catch");
            }

            return aboutUsDto;
        }

        public async Task<List<GetAboutUsDto>> GetAllAsyncAddmin()
        {
            var aboutUsListDto = new List<GetAboutUsDto>();

            try
            {
                var getAllAboutUs = await _unitOfWork.AboutUs.GetAllAboutUsAsync();

                aboutUsListDto = _mapper.Map<List<GetAboutUsDto>>(getAllAboutUs);
                var getAllMedias = await _unitOfWork.Media.GetMediasByEntityRefsAndEntityTypeAndMediaEntityType(aboutUsListDto.Select(s => s.Id).ToList(), EntityType.Project, MediaEntityType.CoverImage);

                foreach (var aboutus in aboutUsListDto)
                {
                    var getMedia = getAllMedias.FirstOrDefault(f => f.EntityRef == aboutus.Id);

                    if (getMedia != null)
                    {
                        aboutus.Persons.ForEach(s => s.CoverMediaId = getMedia.Id);
                        aboutus.Persons.ForEach(s => s.CoverMediaUrl = "https://plansbox.ir/" + getMedia.Media.Url);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetAll method error", typeof(AboutUsServise));

                throw new Exception("erro catch");
            }

            return aboutUsListDto;
        }

        public async Task<List<GetAboutUsDto>> GetAllAsyncWeb()
        {
            var aboutUsListDto = new List<GetAboutUsDto>();

            try
            {
                var getAllAboutUs = await _unitOfWork.AboutUs.GetAllAboutUsWebAsync();

                aboutUsListDto = _mapper.Map<List<GetAboutUsDto>>(getAllAboutUs);
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetAll method error", typeof(AboutUsServise));

                throw new Exception("erro catch");
            }

            return aboutUsListDto;
        }

        public async Task<AboutUsDto> GetById(long id)
        {
            var aboutUsDto = new AboutUsDto();

            try
            {
                var getAboutUs = await _unitOfWork.AboutUs.GetByAboutUsIdAsync(id);

                if (getAboutUs == null)
                {
                    return null;
                }

                aboutUsDto = _mapper.Map<AboutUsDto>(getAboutUs);

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(AboutUsServise));

                throw new Exception("erro catch");
            }

            return aboutUsDto;
        }

        public async Task<bool> DeleTeListAsync(List<long> ids)
        {
            try
            {
                var deleteAboutUss = await _unitOfWork.AboutUs.DeleteListByIds(ids);

                if (deleteAboutUss == false)
                {
                    return false;
                }

            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(AboutUsServise));

                throw new Exception("erro catch");
            }

            return true;
        }


        #region Private Method
        private MediaEntity AddMediaInDataBase(long mediaId, Person newsCast, MediaEntityType mediaEntityType)
        {
            var media = new MediaEntity()
            {
                EntityRef = newsCast.Id,

                EntityType = EntityType.Person,

                MediaEntityType = mediaEntityType,

                MediaRef = mediaId,

                CreationDate = DateTime.Now
            };
            return media;
        }
        #endregion
    }
}
