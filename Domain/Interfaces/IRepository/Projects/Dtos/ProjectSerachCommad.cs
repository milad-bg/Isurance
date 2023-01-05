using Domain.Enums.Project;
using System.Collections.Generic;

namespace Domain.Interfaces.IRepository.Projects.Dtos
{
    public class ProjectSerachCommad
    {
        public int PageNuber { get; set; }

        public int PageSize { get; set; }


        public List<long> Cities { get; set; }
        public List<long> Type { get; set; }
        public List<long> State { get; set; }

        public ProjectSerachCommad(int pageNumber, int pageSize,List<long> cities, List<long> type, List<long> state )
        {
            PageNuber = pageNumber;
            PageSize = pageSize;
            Cities = cities;
            State = state;
            Type = type;
        }
    }
}
