using Domain.Commands;
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

        public void Update(UpdateProjectCommand updateProjectCommand)
        {
            this.Title = updateProjectCommand.Title;
            this.State = updateProjectCommand.State;
            this.Priority = updateProjectCommand.Priority;
            this.Content = updateProjectCommand.Content;
            this.Description = updateProjectCommand.Description;
            this.CityId = updateProjectCommand.City.Id;
            this.LastUpdateDate = DateTime.Now;
        }
    }
}
