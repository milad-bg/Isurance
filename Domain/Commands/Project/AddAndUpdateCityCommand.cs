using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
    public class AddAndUpdateCityCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
