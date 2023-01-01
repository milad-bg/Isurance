using Application.Servises.Files.Dtos;
using System;
using System.Collections.Generic;

namespace Application.Servises.Informaiton.Dtos
{
    public class AddAboutUsDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public List<AddPersonDto> Persons { get; set; }

        public AddAboutUsDto()
        {
            Persons = new List<AddPersonDto>();
        }

    }
}
