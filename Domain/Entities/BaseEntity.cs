using System;

namespace Domain.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
