using System.Collections.Generic;

namespace Domain.Domain.Entities.Projects
{
    public class City : BaseEntity
    {
        public string Title { get; set; }

        public bool IsFeatured { get; set; }

        public int Priority { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();
    }
}
