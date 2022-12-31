using Application.Servises.Users.Command;
using AutoMapper;
using Domain.Interfaces.IUnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Servises.Users
{
    public class UserService : IUserservice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public async Task<bool> Login(LoginCommand command)
        {
            try
            {
                var isExistUser = await _unitOfWork.User.IsExistUser(command.UserName, command.Password);

                if (isExistUser ==  null)
                {
                    return false;
                }
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "{Repo} Add method error");

                throw new Exception("erro catch");
            }

            return true;
        }
    }
}
