using System.Collections.Generic;

namespace Application.Servises.Informaiton.Commads
{
    public class EditAboutUsCommand
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public bool IsFeatured { get; set; }

        public int Priority { get; set; }

    }
}
