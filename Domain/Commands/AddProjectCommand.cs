using Domain.Domain.Entities.Projects;
using Domain.Enums.Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
    public class AddProjectCommand
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public ProjectState State { get; set; }
        public ProjectPriority Priority { get; set; }

        public AddCityCommand City { get; set; }
    }
}
