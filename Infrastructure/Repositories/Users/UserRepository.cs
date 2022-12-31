﻿using Domain.Domain.Entities;
using Domain.Interfaces.IRepository.Users;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseDbcontext context) : base(context) { }

        public async Task<User> IsExistUser(string userName, string Password)
        {
            return await dbSet.FirstOrDefaultAsync(f => f.UserName == userName && f.Password == Password);
        }
    }
}