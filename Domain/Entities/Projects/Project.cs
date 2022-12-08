using Domain.Enums.Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Entities.Projects
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public ProjectState State { get; set; }
        public ProjectPriority Priority { get; set; }

        #region navigation
        public City City { get; set; }
        public long CityId { get; set; }
        #endregion

    }
}
