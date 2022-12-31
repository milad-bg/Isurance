using Domain.Enums.Project;
using System.Collections.Generic;

namespace Domain.Interfaces.IRepository.Projects.Dtos
{
    public class ProjectSerachCommad
    {
        public int PageNuber { get; set; }

        public int PageSize { get; set; }

        public ProjectState StateDone { get; set; }

        public ProjectState StateInprocess { get; set; }

        public ProjectType ProjectTypePerformance { get; set; }

        public ProjectType ProjectTypeSupervision { get; set; }

        public List<long> Cities { get; set; }

        public ProjectSerachCommad(int pageNumber, int pageSize, ProjectState stateDone, ProjectState stateInprocess, ProjectType projectTypePerformance, ProjectType projectTypeSupervision, List<long> cities)
        {
            PageNuber = pageNumber;
            PageSize = pageSize;
            StateDone = stateDone;
            StateInprocess = stateInprocess;
            ProjectTypePerformance = projectTypePerformance;
            ProjectTypeSupervision = projectTypeSupervision;
            Cities = cities;
        }
    }
}
