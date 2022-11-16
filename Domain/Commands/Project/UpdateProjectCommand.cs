using Domain.Enums.Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
    public class UpdateProjectCommand
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public ProjectState State { get; set; }
        public ProjectPriority Priority { get; set; }

        public AddAndUpdateCityCommand City { get; set; }
    }
}
