using Domain.Enums.Project;
using System;

namespace Application.Servises.Projects.Dtos
{
    public class SearchProjectDto
    {
        public string Title { get; set; }

        public long Id { get; set; }

        public string Description { get; set; }

        public ProjectState State { get; set; }

        public ProjectType Type { get; set; }

        public string UpperContent { get; set; }

        public string DownContent { get; set; }

        public string CityTitle { get; set; }

        public DateTime CreationDate { get; set; }

        public long CoverMediaId { get; set; }
        public string CoverMediaUrl { get; set; }
    }
}
