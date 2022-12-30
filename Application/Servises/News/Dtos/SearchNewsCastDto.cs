using System;

namespace Application.Servises.News.Dtos
{
    public class SearchNewsCastDto
    {
        public string Title { get; set; }

        public long Id { get; set; }

        public string Description { get; set; }

        public string UpperContent { get; set; }

        public string DownContent { get; set; }

        public DateTime CreationDate { get; set; }

        public long CoverMediaId { get; set; }
        public string CoverMediaUrl { get; set; }
    }
}
