using Domain.Enums.Project;
using System.Collections.Generic;

namespace Application.Servises.News.Commads
{
    public class AddProjectCommand
    {
        public long cityRef { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ProjectState State { get; set; }

        public ProjectType Type { get; set; }

        public int Priority { get; set; }

        public string UpperContent { get; set; }

        public string DownContent { get; set; }

        public bool IsFeatured { get; set; }

        public long CoverMediaId { get; set; }

        public List<long> Medias { get; set; }
    }
}
