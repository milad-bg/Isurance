using Domain.Enums.Project;
using System.Collections.Generic;

namespace Application.Servises.Projects.Commads
{
    public class ProjectWebCommad
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public ProjectState StateDone { get; set; } = 0;

        public ProjectState StateInprocess { get; set; } = 0;

        public ProjectType ProjectTypePerformance { get; set; } = 0;

        public ProjectType ProjectTypeSupervision { get; set; } = 0;

        public List<long> Cities { get; set; }
     }
}
