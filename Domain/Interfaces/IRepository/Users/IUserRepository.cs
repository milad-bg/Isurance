using Domain.Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository.Users
{
    public interface IUserRepository
    {
        Task<User> IsExistUser(string userName, string Password);
    }
}
