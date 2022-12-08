namespace Application.Servises.News.Commads
{
    public class EditNewsCastCommand
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool IsFeatured { get; set; }

        public byte IsFeaturedPriority { get; set; }

        public long Priority { get; set; }
    }
}
