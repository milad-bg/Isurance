using Application.Servises.Tenders.Command;
using Application.Servises.Tenders.Dto;
using AutoMapper;
using Domain.Domain.Entities.Tendor;
using Domain.Interfaces.IUnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises.Tenders
{
    public class TenderService : ITenderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public TenderService(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(AddTendreCommand command)
        {
            try
            {
                var mapTender = _mapper.Map<Tender>(command);

                mapTender.CreationDate = DateTime.Now;

                var addNews = await _unitOfWork.Tender.AddTenderAsync(mapTender);

                if (addNews == null)
                {
                    return false;
                }
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(TenderService));

                throw new Exception("erro catch");
            }

            return true;
        }

        public async Task<List<TendersDto>> GetAllAdmin()
        {
            var listTenders = new List<TendersDto>();

            try
            {
                var getAllTenders = await _unitOfWork.Tender.GetAllProjectAsync();

                listTenders = _mapper.Map<List<TendersDto>>(getAllTenders);
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(TenderService));

                throw new Exception("erro catch");
            }

            return listTenders;
        }

        public async Task<TendersDto> GetById(long id)
        {
            var getTender = new TendersDto();

            try
            {
                var tender = await _unitOfWork.Tender.GetById(id);

                if (tender == null)
                {
                    return null;
                }

                getTender = _mapper.Map<TendersDto>(tender);

            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error", typeof(TenderService));

                throw new Exception("erro catch");
            }

            return getTender;

        }
    }
}
