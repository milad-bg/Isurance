using System;

namespace Application.Servises.Cities.Dtos
{
    public class GetCityDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public bool IsFeatured { get; set; }

        public int Priority { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
