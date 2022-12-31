using Domain.Enums.Project;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Application.Servises.News.Commads
{
    public class AddProjectCommand
    {
        public long CityRef { get; set; }

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

        public long CoverMediaId { get; set; }

        public List<long> Medias { get; set; }
    }
}
