using System;
using System.Collections.Generic;

namespace Application.Servises.Informaiton.Dtos
{
    public class GetAboutUsDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public bool IsFeatured { get; set; }

        public int Priority { get; set; }

        public DateTime CreationDate { get; set; }

        public List<AddPersonDto> Persons { get; set; }

        public GetAboutUsDto()
        {
            Persons = new List<AddPersonDto>();
        }
    }
}
