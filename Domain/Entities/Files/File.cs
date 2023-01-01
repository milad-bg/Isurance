using Domain.Enums.Flies;
using System.Collections.Generic;

namespace Domain.Domain.Entities.File
{
    public class File : BaseEntity
    {
        public string FilePath { get; set; }

        public string Url { get; set; }

        public long Size { get; set; }
    
        public MediaType MediaEntity { get; set; }

        public virtual ICollection<MediaEntity> MediaEntities { get; set; } = new HashSet<MediaEntity>();
    }
}
