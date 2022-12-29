using Application.Servises.Files.Dtos;
using Application.Servises.News.Commads;
using Application.Servises.News.Dtos;
using AutoMapper;
using Domain.Domain.Entities.File;
using Domain.Domain.Entities.Healper;
using Domain.Domain.Entities.Projects;
using Domain.Enums;
using Domain.Enums.Flies;
using Domain.Interfaces.IUnitOfWork;
using Infrastructure.UnitOFWorks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises.Projects
{
    public class ProjectAppService : IProjectAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ProjectAppService(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public List<Project> GetAllProjectsWeb(PagingParameters parameters)
        {
            return _unitOfWork.Project
                .GetProjects(parameters.PageNumber, parameters.PageSize);
        }

        public async Task<AddProjectDto> AddAsync(AddProjectCommand command)
        {
            var ProjectDto = new AddProjectDto();

            try
            {
                var mapNews = _mapper.Map<Project>(command);

                mapNews.CreationDate = DateTime.Now;

                var addNews = await _unitOfWork.Project.AddProjectAsync(mapNews);

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

                ProjectDto = _mapper.Map<AddProjectDto>(mapNews);


                if (addMedias == true)
                {
                    var getCoverMedia = await _unitOfWork.File.GetFileByIdAsync(command.CoverMediaId);

                    if (getCoverMedia != null)
                    {
                        ProjectDto.CoverMediaId = getCoverMedia.Id;
                        ProjectDto.CoverMediaUrl = "https://plansbox.ir/" + getCoverMedia.Url;
                    }

                    var getMedias = await _unitOfWork.File.GetMediaByIds(command.Medias);

                    foreach (var item in getMedias)
                    {
                        ProjectDto.Medias.Add(new MediasDto()
                        {
                            Id = item.Id,
                            Url = "https://plansbox.ir/" + item.Url
                        });
                    }
                }
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(ProjectAppService));

                throw new Exception("erro catch");
            }

            return ProjectDto;
        }

        public async Task<EditProjectDto> EditAsync(EditProjectCommand command)
        {
            var ProjectDto = new EditProjectDto();

            try
            {
                var getProject = await _unitOfWork.Project.GetByProjectIdAsync(command.Id);

                if (getProject == null)
                {
                    return null;
                }

                var mapProject = _mapper.Map(command, getProject);

                mapProject.LastUpdateDate = DateTime.Now;

                var EditProject = await _unitOfWork.Project.EditProjectAsync(mapProject);

                ProjectDto = _mapper.Map<EditProjectDto>(EditProject);

                var ProjectMedias = new List<MediaEntity>();

                var deletemediaentityeimage = await _unitOfWork.Media.DeleteMeidaByEntityRefAndEntityTypeAndMediaEntityType(getProject.Id, EntityType.Project, MediaEntityType.CoverImage);

                if (command.CoverMediaId != 0)
                {
                    var coverMedia = AddMediaInDataBase(command.CoverMediaId, getProject, MediaEntityType.CoverImage);

                    ProjectMedias.Add(coverMedia);
                }

                if (command.Medias.Count() != 0)
                {
                    var deleteMediaEntitye = await _unitOfWork.Media.DeleteMeidaByEntityRefAndEntityTypeAndMediaEntityType(getProject.Id, EntityType.Project, MediaEntityType.Image);

                    foreach (var media in command.Medias.Where(w => w != 0))
                    {
                        var imageMedia = AddMediaInDataBase(media, getProject, MediaEntityType.Image);

                        ProjectMedias.Add(imageMedia);
                    }
                }

                var addMedias = false;

                if (ProjectMedias.Any())
                {
                    addMedias = await _unitOfWork.Media.AddRangeAsync(ProjectMedias);
                }


                if (addMedias == true)
                {
                    var getCoverMedia = await _unitOfWork.File.GetFileByIdAsync(command.CoverMediaId);

                    if (getCoverMedia != null)
                    {
                        ProjectDto.CoverMediaId = getCoverMedia.Id;
                        ProjectDto.CoverMediaUrl = "https://plansbox.ir/" + getCoverMedia.Url;
                    }

                    var getMedias = await _unitOfWork.File.GetMediaByIds(command.Medias.Where(w => w != 0).ToList());

                    foreach (var item in getMedias)
                    {
                        ProjectDto.Medias.Add(new MediasDto()
                        {
                            Id = item.Id,
                            Url = "https://plansbox.ir/" + item.Url
                        });
                    }
                }
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(ProjectAppService));

                throw new Exception("erro catch");
            }

            return ProjectDto;
        }

        public async Task<List<GetProjectDto>> GetAllAsyncAddmin()
        {
            var ProjectListDto = new List<GetProjectDto>();

            try
            {
                var getAllProject = await _unitOfWork.Project.GetAllProjectAsync();

                ProjectListDto = _mapper.Map<List<GetProjectDto>>(getAllProject);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetAll method error", typeof(ProjectAppService));

                throw new Exception("erro catch");
            }

            return ProjectListDto;
        }

        public async Task<ProjectDto> GetById(long id)
        {
            var ProjectDto = new ProjectDto();

            try
            {
                var getProject = await _unitOfWork.Project.GetByProjectIdAsync(id);

                if (getProject == null)
                {
                    return null;
                }

                ProjectDto = _mapper.Map<ProjectDto>(getProject);

                var getAllMediaProject = await _unitOfWork.Media.GetMediasByEntityRefAndEntityType(getProject.Id, EntityType.Project);

                if (getAllMediaProject.Count() != 0)
                {
                    var getCoverMedia = getAllMediaProject.FirstOrDefault(f => f.MediaEntityType == MediaEntityType.CoverImage);

                    if (getCoverMedia != null)
                    {
                        ProjectDto.CoverMediaId = getAllMediaProject.FirstOrDefault(f => f.MediaEntityType == MediaEntityType.CoverImage).Media.Id;
                        ProjectDto.CoverMediaUrl = "https://plansbox.ir/" + getAllMediaProject.FirstOrDefault(f => f.MediaEntityType == MediaEntityType.CoverImage).Media.Url;
                    }

                    ProjectDto.Medias = _mapper.Map<List<MediasDto>>(getAllMediaProject.Where(w => w.MediaEntityType == MediaEntityType.Image));
                }

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(ProjectAppService));

                throw new Exception("erro catch");
            }

            return ProjectDto;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var getProject = await _unitOfWork.Project.GetByProjectIdAsync(id);

                if (getProject == null)
                {
                    return false;
                }

                var deleteProject = await _unitOfWork.Project.DeleteProjectAsync(id);

                if (deleteProject == false)
                {
                    return false;
                }

                var deleteImage = await _unitOfWork.Media.DeleteByEntityRefAndEntityType(id, EntityType.Project);

                if (deleteImage == false)
                {
                    return false;
                }
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(ProjectAppService));

                throw new Exception("erro catch");
            }

            return true;
        }

        public async Task<bool> DeleTeListAsync(List<long> ids)
        {
            try
            {
                var deleteProjects = await _unitOfWork.Project.DeleteListByIds(ids);

                if (deleteProjects == false)
                {
                    return false;
                }

                var deleteAllImage = await _unitOfWork.Media.DeleteByEnityRefsAndEntityType(ids, EntityType.Project);

                if (deleteAllImage == false)
                {
                    return false;
                }
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(ProjectAppService));

                throw new Exception("erro catch");
            }

            return true;
        }

        #region Private Method
        private MediaEntity AddMediaInDataBase(long mediaId, Project Project, MediaEntityType mediaEntityType)
        {
            var media = new MediaEntity()
            {
                EntityRef = Project.Id,

                EntityType = EntityType.Project,

                MediaEntityType = mediaEntityType,

                MediaRef = mediaId,

                CreationDate = DateTime.Now
            };
            return media;
        }
        #endregion
    }
}
