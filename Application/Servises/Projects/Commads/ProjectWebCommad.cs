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

        public List<long> Cities { get; set; }

        public List<long> Type { get; set; }

        public List<long> State { get; set; }
     }
}
