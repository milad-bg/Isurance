using Domain.Enums.Project;

namespace Domain.Interfaces.IRepository.Projects.Dtos
{
    public class SearchProjectsDto
    {
        public string Title { get; set; }

        public long Id { get; set; }

        public string Description { get; set; }

        public ProjectState State { get; set; }

        public ProjectType Type { get; set; }

        public string UpperContent { get; set; }

        public string DownContent { get; set; }

        public string CityTitle { get; set; }
    }
}
