using Domain.Enums;
using Domain.Enums.Flies;

namespace Domain.Domain.Entities.File
{
    public class MediaEntity : BaseEntity
    {
        public long MediaRef { get; set; }
        public virtual File Media { get; set; }

        public EntityType EntityType { get; set; }

        public long EntityRef { get; set; }

        public MediaEntityType MediaEntityType { get; set; }
    }
}
