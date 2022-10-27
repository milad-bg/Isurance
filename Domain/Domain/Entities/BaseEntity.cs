using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
