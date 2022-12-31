using Domain.Domain.Entities;

namespace Domain.Entities
{
    public class Login : BaseEntity
    {
        public string Password { get; set; }

        public string UserName { get; set; }
    }
}

