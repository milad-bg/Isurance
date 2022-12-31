using Application.Servises.Files.Dtos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Application.Servises.News.Dtos
{
    public class NewsCastDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [AllowHtml]
        public string UpperContent { get; set; }

        [AllowHtml]
        public string DownContent { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsFeaturedPriority { get; set; }

        public int FeaturedPriority { get; set; }

        public int Priority { get; set; }

        public DateTime CreationDate { get; set; }

        public long CoverMediaId { get; set; }
        public string CoverMediaUrl { get; set; }

        public List<MediasDto> Medias { get; set; }

        public NewsCastDto()
        {
            Medias = new List<MediasDto>();
        }
    }
}
