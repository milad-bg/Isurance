namespace Application.Servises.News.Dtos
{
    public class AddNewsCastDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool IsFeatured { get; set; }

        public byte IsFeaturedPriority { get; set; }

        public long Priority { get; set; }

        public bool IsSucceed { get; set; }
    }
}
