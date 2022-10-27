using Microsoft.AspNetCore.Identity;

namespace Domain.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public string NationalCode { get; set; }
    }
}
