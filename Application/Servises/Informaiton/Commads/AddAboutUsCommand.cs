using System.Collections.Generic;

namespace Application.Servises.Informaiton.Commads
{
    public class AddAboutUsCommand
    {
        public string Title { get; set; }

        public List<AddPersonCommand> Persons { get; set; }

        public AddAboutUsCommand()
        {
            Persons = new List<AddPersonCommand>();
        }
    }
}
