using Application.Servises.Files.Dtos;
using Application.Servises.News.Commads;
using Application.Servises.News.Dtos;
using AutoMapper;
using Domain.Domain.Entities.File;
using Domain.Domain.Entities.Healper;
using Domain.Domain.Entities.News;
using Domain.Enums;
using Domain.Enums.Flies;
using Domain.Interfaces.IUnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Servises.News
{
    public class NewsCastServise : INewsCastService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public NewsCastServise(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AddNewsCastDto> AddAsync(AddNewsCastCommand command)
        {
            var newsCastDto = new AddNewsCastDto();

            try
            {
                var mapNews = _mapper.Map<NewsCast>(command);

                mapNews.CreationDate = DateTime.Now;

                var addNews = await _unitOfWork.NewsCast.AddNewsCastAsync(mapNews);

                var mediaEntity = new List<MediaEntity>();

                if (command.CoverMediaId != 0)
                {
                    var AddmediaCover = AddMediaInDataBase(command.CoverMediaId, addNews, MediaEntityType.CoverImage);

                    mediaEntity.Add(AddmediaCover);
                }

                if (command.Medias.Count() != 0)
                {
                    command.Medias.Where(w => w != 0).ToList().ForEach(f =>
                      {
                          var AddmediaCover = AddMediaInDataBase(f, addNews, MediaEntityType.Image);

                          mediaEntity.Add(AddmediaCover);
                      });
                }

                var addMedias = false;

                if (mediaEntity.Any())
                {
                    addMedias = await _unitOfWork.Media.AddRangeAsync(mediaEntity);
                }

                newsCastDto = _mapper.Map<AddNewsCastDto>(mapNews);


                if (addMedias == true)
                {
                    var getCoverMedia = await _unitOfWork.File.GetFileByIdAsync(command.CoverMediaId);

                    if (getCoverMedia != null)
                    {
                        newsCastDto.CoverMediaId = getCoverMedia.Id;
                        newsCastDto.CoverMediaUrl = "https://plansbox.ir/" + getCoverMedia.Url;
                    }

                    var getMedias = await _unitOfWork.File.GetMediaByIds(command.Medias);

                    foreach (var item in getMedias)
                    {
                        newsCastDto.Medias.Add(new MediasDto()
                        {
                            Id = item.Id,
                            Url = "https://plansbox.ir/" + item.Url
                        });
                    }
                }
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(NewsCastServise));

                throw new Exception("erro catch");
            }

            return newsCastDto;
        }

        public async Task<EditNewsCastDto> EditAsync(EditNewsCastCommand command)
        {
            var newsCastDto = new EditNewsCastDto();

            try
            {
                var getNewsCast = await _unitOfWork.NewsCast.GetByNewsCastIdAsync(command.Id);

                if (getNewsCast == null)
                {
                    return null;
                }

                var mapNewsCast = _mapper.Map(command, getNewsCast);

                mapNewsCast.LastUpdateDate = DateTime.Now;

                var EditNewsCast = await _unitOfWork.NewsCast.EditNewsCastAsync(mapNewsCast);

                newsCastDto = _mapper.Map<EditNewsCastDto>(EditNewsCast);

                var newsCastMedias = new List<MediaEntity>();

                var deletemediaentityeimage = await _unitOfWork.Media.DeleteMeidaByEntityRefAndEntityTypeAndMediaEntityType(getNewsCast.Id, EntityType.NewsCast, MediaEntityType.CoverImage);

                if (command.CoverMediaId != 0)
                {
                    var coverMedia = AddMediaInDataBase(command.CoverMediaId, getNewsCast, MediaEntityType.CoverImage);

                    newsCastMedias.Add(coverMedia);
                }

                if (command.Medias.Count() != 0)
                {
                    var deleteMediaEntitye = await _unitOfWork.Media.DeleteMeidaByEntityRefAndEntityTypeAndMediaEntityType(getNewsCast.Id, EntityType.NewsCast, MediaEntityType.Image);

                    foreach (var media in command.Medias.Where(w => w != 0))
                    {
                        var imageMedia = AddMediaInDataBase(media, getNewsCast, MediaEntityType.Image);

                        newsCastMedias.Add(imageMedia);
                    }
                }

                var addMedias = false;

                if (newsCastMedias.Any())
                {
                    addMedias = await _unitOfWork.Media.AddRangeAsync(newsCastMedias);
                }


                if (addMedias == true)
                {
                    var getCoverMedia = await _unitOfWork.File.GetFileByIdAsync(command.CoverMediaId);

                    if (getCoverMedia != null)
                    {
                        newsCastDto.CoverMediaId = getCoverMedia.Id;
                        newsCastDto.CoverMediaUrl = "https://plansbox.ir/" + getCoverMedia.Url;
                    }

                    var getMedias = await _unitOfWork.File.GetMediaByIds(command.Medias.Where(w => w != 0).ToList());

                    foreach (var item in getMedias)
                    {
                        newsCastDto.Medias.Add(new MediasDto()
                        {
                            Id = item.Id,
                            Url = "https://plansbox.ir/" + item.Url
                        });
                    }
                }
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(NewsCastServise));

                throw new Exception("erro catch");
            }

            return newsCastDto;
        }

        public async Task<List<GetNewsCastDto>> GetAllAsyncAddmin()
        {
            var newsCastListDto = new List<GetNewsCastDto>();

            try
            {
                var getAllNewsCast = await _unitOfWork.NewsCast.GetAllNewsCastAsync();

                newsCastListDto = _mapper.Map<List<GetNewsCastDto>>(getAllNewsCast);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetAll method error", typeof(NewsCastServise));

                throw new Exception("erro catch");
            }

            return newsCastListDto;
        }

        public async Task<List<GetNewsCastDto>> GetAllAsyncWeb(PagingParameters parameters)
        {
            var newsCastListDto = new List<GetNewsCastDto>();

            try
            {
                var getAllNewsCast = await _unitOfWork.NewsCast.GetAllNewsCastWebAsync(parameters.PageNumber , parameters.PageSize);

                newsCastListDto = _mapper.Map<List<GetNewsCastDto>>(getAllNewsCast);

                var getAllMedias = await _unitOfWork.Media.GetMediasByEntityRefsAndEntityTypeAndMediaEntityType(getAllNewsCast.Select(s => s.Id).ToList(), EntityType.NewsCast, MediaEntityType.CoverImage);

                foreach (var newsCast in newsCastListDto)
                {
                    var getMedia = getAllMedias.FirstOrDefault(f => f.EntityRef == newsCast.Id);
                        
                    if (getMedia != null)
                    {
                        newsCast.CoverMediaId = getMedia.Media.Id;

                        newsCast.CoverMediaUrl = "https://plansbox.ir/" + getMedia.Media.Url;
                    }
                }

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetAll method error", typeof(NewsCastServise));

                throw new Exception("erro catch");
            }

            return newsCastListDto;
        }

        public async Task<NewsCastDto> GetById(long id)
        {
            var newsCastDto = new NewsCastDto();

            try
            {
                var getNewsCast = await _unitOfWork.NewsCast.GetByNewsCastIdAsync(id);

                if (getNewsCast == null)
                {
                    return null;
                }

                newsCastDto = _mapper.Map<NewsCastDto>(getNewsCast);

                var getAllMediaNewsCast = await _unitOfWork.Media.GetMediasByEntityRefAndEntityType(getNewsCast.Id, EntityType.NewsCast);

                if (getAllMediaNewsCast.Count() != 0)
                {
                    var getCoverMedia = getAllMediaNewsCast.FirstOrDefault(f => f.MediaEntityType == MediaEntityType.CoverImage);

                    if (getCoverMedia != null)
                    {
                        newsCastDto.CoverMediaId = getAllMediaNewsCast.FirstOrDefault(f => f.MediaEntityType == MediaEntityType.CoverImage).Media.Id;
                        newsCastDto.CoverMediaUrl = "https://plansbox.ir/" + getAllMediaNewsCast.FirstOrDefault(f => f.MediaEntityType == MediaEntityType.CoverImage).Media.Url;
                    }

                    newsCastDto.Medias = _mapper.Map<List<MediasDto>>(getAllMediaNewsCast.Where(w => w.MediaEntityType == MediaEntityType.Image));
                }

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(NewsCastServise));

                throw new Exception("erro catch");
            }

            return newsCastDto;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var getNewsCast = await _unitOfWork.NewsCast.GetByNewsCastIdAsync(id);

                if (getNewsCast == null)
                {
                    return false;
                }

                var deleteNewsCast = await _unitOfWork.NewsCast.DeleteNewsCastAsync(id);

                if (deleteNewsCast == false)
                {
                    return false;
                }

                var getMediaProject = await _unitOfWork.Media.GetMediasByEntityRefAndEntityType(id, EntityType.NewsCast);

                if (getMediaProject.Count() != 0)
                {
                    var deleteImage = await _unitOfWork.Media.DeleteByEntityRefAndEntityType(id, EntityType.NewsCast);

                }
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(NewsCastServise));

                throw new Exception("erro catch");
            }

            return true;
        }

        public async Task<bool> DeleTeListAsync(List<long> ids)
        {
            try
            {
                var deleteNewsCasts = await _unitOfWork.NewsCast.DeleteListByIds(ids);

                if (deleteNewsCasts == false)
                {
                    return false;
                }

                var deleteAllImage = await _unitOfWork.Media.DeleteByEnityRefsAndEntityType(ids, EntityType.NewsCast);

            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(NewsCastServise));

                throw new Exception("erro catch");
            }

            return true;
        }

        #region Private Method
        private MediaEntity AddMediaInDataBase(long mediaId, NewsCast newsCast, MediaEntityType mediaEntityType)
        {
            var media = new MediaEntity()
            {
                EntityRef = newsCast.Id,

                EntityType = EntityType.NewsCast,

                MediaEntityType = mediaEntityType,

                MediaRef = mediaId,

                CreationDate = DateTime.Now
            };
            return media;
        }

        #endregion
    }
}
