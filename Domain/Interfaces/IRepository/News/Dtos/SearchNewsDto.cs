namespace Domain.Interfaces.IRepository.News.Dtos
{
    public class SearchNewsDto
    {
        public string Title { get; set; }

        public long Id { get; set; }

        public string Description { get; set; }

        public string UpperContent { get; set; }

        public string DownContent { get; set; }
    }
}
