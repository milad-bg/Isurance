using Domain.Enums.Project;

namespace Domain.Domain.Entities.Projects
{
    public class Project : BaseEntity
    {

        #region navigation
        public virtual City City { get; set; }
        public long CityRef { get; set; }
        #endregion

        public string Title { get; set; }

        public string Description { get; set; }

        public ProjectState State { get; set; }

        public ProjectType Type { get; set; }

        public int Priority { get; set; }

        public string UpperContent { get; set; }

        public string DownContent { get; set; }

        public bool IsFeatured { get; set; }
    }
}
