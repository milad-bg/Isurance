using Domain.Domain.Entities;
using Domain.Domain.Entities.Tendor;
using System.Collections.Generic;

namespace Domain.Entities.Tenders
{
    public class ProductService : BaseEntity
    {
        public string Title { get; set; }

        public int Priority { get; set; }

        public bool IsFeature { get; set; }

        public virtual ICollection<Tender> Tenders { get; set; } = new HashSet<Tender>();
    }
}
