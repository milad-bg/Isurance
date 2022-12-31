using System;

namespace Domain.Domain.Entities.News
{
    public class NewsCast : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string UpperContent { get; set; }

        public string DownContent { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsFeaturedPriority { get; set; }

        public int FeaturedPriority { get; set; }

        public int Priority { get; set; }
    }
}
