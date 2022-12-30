using System;

namespace Application.Servises.Informaiton.Dtos
{
    public class GetAboutUsDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public bool IsFeatured { get; set; }

        public int Priority { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
