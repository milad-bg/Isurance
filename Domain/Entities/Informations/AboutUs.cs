
using System.Collections.Generic;

namespace Domain.Domain.Entities.Information
{
    public class AboutUs : BaseEntity
    {
       public string Title { get; set; }

        public virtual ICollection<Person> Persons { get; set; } = new HashSet<Person>();
    }
}
    