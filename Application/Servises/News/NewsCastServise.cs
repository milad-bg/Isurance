using Application.Servises.News.Commads;
using Application.Servises.News.Dtos;
using AutoMapper;
using Domain.Domain.Entities.News;
using Domain.Interfaces.IUnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

                if (addNews != true)
                {
                    throw new Exception("افزودن اخبار با خطا مواجه شد");
                }

                newsCastDto = _mapper.Map<AddNewsCastDto>(mapNews);
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
                    throw new Exception("اخبار مورد نظر شما یافت نشد");
                }

                var mapNewsCast = _mapper.Map(command, getNewsCast);

                mapNewsCast.LastUpdateDate = DateTime.Now;

                var EditNewsCast = await _unitOfWork.NewsCast.EditNewsCastAsync(mapNewsCast);

                newsCastDto = _mapper.Map<EditNewsCastDto>(EditNewsCast);
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(NewsCastServise));

                throw new Exception("erro catch");
            }

            return newsCastDto;
        }

        public async Task<List<NewsCastDto>> GetAllAsync()
        {
            var newsCastListDto = new List<NewsCastDto>();

            try
            {
                var getAllNewsCast = await _unitOfWork.NewsCast.GetAllNewsCastAsync();

                newsCastListDto = _mapper.Map<List<NewsCastDto>>(getAllNewsCast);
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
                    throw new Exception("اخبار مورد نظر شما یافت نشد");
                }

                newsCastDto = _mapper.Map<NewsCastDto>(getNewsCast);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} GetById method error", typeof(NewsCastServise));

                throw new Exception("erro catch");
            }

            return newsCastDto;
        }
    }
}
