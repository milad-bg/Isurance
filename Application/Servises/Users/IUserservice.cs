using Application.Servises.Users.Command;
using System.Threading.Tasks;

namespace Application.Servises.Users
{
    public interface IUserservice
    {
        Task<bool> Login(LoginCommand command);

    }
}
