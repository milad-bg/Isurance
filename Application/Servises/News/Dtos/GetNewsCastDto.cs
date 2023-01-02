using System;

namespace Application.Servises.News.Dtos
{
    public class GetNewsCastDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsFeaturedPriority { get; set; }

        public int FeaturedPriority { get; set; }

        public int Priority { get; set; }

        public DateTime CreatDate { get; set; }

        public long CoverMediaId { get; set; }
        public string CoverMediaUrl { get; set; }
    }
}
