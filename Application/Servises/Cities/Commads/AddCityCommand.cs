﻿using System.Collections.Generic;

namespace Application.Servises.Cities.Commads
{
    public class AddCityCommand
    {
        public string Title { get; set; }

        public bool IsFeatured { get; set; }

        public int Priority { get; set; }
    }
}