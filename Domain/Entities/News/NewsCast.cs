namespace Domain.Domain.Entities.News
{
    public class NewsCast : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool IsFeatured { get; set; }

        public byte IsFeaturedPriority { get; set; }

        public long Priority { get; set; }
    }
}
