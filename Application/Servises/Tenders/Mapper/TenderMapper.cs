using Application.Servises.Tenders.Command;
using Application.Servises.Tenders.Dto;
using AutoMapper;
using Domain.Domain.Entities.Tendor;

namespace Application.Servises.Tenders.Mapper
{
    public class TenderMapper : Profile
    {
        public TenderMapper()
        {
            CreateMap<AddTendreCommand, Tender>();

            CreateMap<Tender, TendersDto>();
        }
    }
}
