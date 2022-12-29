using Domain.Enums.Project;
using System;

namespace Application.Servises.News.Dtos
{
    public class GetProjectDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ProjectState State { get; set; }

        public ProjectType Type { get; set; }

        public int Priority { get; set; }

        public string UpperContent { get; set; }

        public string DownContent { get; set; }

        public bool IsFeatured { get; set; }

        public DateTime CreationDate { get; set; }

        public long CoverMediaId { get; set; }
        public string CoverMediaUrl { get; set; }
    }
}
