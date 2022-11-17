using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto_s
{
    public class CityDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
