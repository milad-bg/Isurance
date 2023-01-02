using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Servises.Tenders.Dto
{
    public class ProductServiceDto
    {
        public string Title { get; set; }

        public int Priority { get; set; }

        public bool IsFeature { get; set; }

        public virtual List<TendersDto> Tenders { get; set; }

        public ProductServiceDto()
        {
            Tenders = new List<TendersDto>();
        }
    }
}
