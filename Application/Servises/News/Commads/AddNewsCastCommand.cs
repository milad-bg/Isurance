using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Application.Servises.News.Commads
{
    public class AddNewsCastCommand
    {
        public string Title { get; set; }

        [AllowHtml]
        public string UpperContent { get; set; }

        public string Description { get; set; }

        [AllowHtml]
        public string DownContent { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsFeaturedPriority { get; set; }

        public int FeaturedPriority { get; set; }

        public int Priority { get; set; }

        public long CoverMediaId { get; set; }

        public DateTime CreatDate { get; set; }

        public List<long> Medias { get; set; }
    }
}
