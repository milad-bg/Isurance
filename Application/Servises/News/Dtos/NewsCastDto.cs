using Domain.Enums.News;

namespace Application.Servises.News.Dtos
{
    public class NewsCastDto
    {

        public string Description { get; set; }

        public string Content { get; set; }

        public bool IsFeatured { get; set; }

        public byte IsFeaturedPriority { get; set; }

        public NewsPriority NewsPriority { get; set; }
    }
}
