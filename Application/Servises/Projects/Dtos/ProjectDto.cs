using Application.Servises.Files.Dtos;
using Domain.Enums.Project;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Application.Servises.News.Dtos
{
    public class ProjectDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ProjectState State { get; set; }

        public ProjectType Type { get; set; }

        public int Priority { get; set; }

        [AllowHtml]
        public string UpperContent { get; set; }

        [AllowHtml]
        public string DownContent { get; set; }

        public bool IsFeatured { get; set; }

        public DateTime CreationDate { get; set; }

        public long CityId { get; set; }

        public string CityTitle { get; set; }

        public long CoverMediaId { get; set; }
        public string CoverMediaUrl { get; set; }

        public List<MediasDto> Medias { get; set; }

        public ProjectDto()
        {
            Medias = new List<MediasDto>();
        }
    }
}
