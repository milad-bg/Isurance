using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Servises.Tenders.Command
{
    public class ProductServiceCommand
    {
        public string Title { get; set; }

        public int Priority { get; set; }

        public bool IsFeature { get; set; }
    }
}
