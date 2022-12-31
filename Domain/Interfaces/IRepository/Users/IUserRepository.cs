using Domain.Domain.Entities;
using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Users
{
    public interface IUserRepository
    {
        Task<Login> IsExistUser(string userName, string Password);
    }
}
