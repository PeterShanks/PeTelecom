﻿using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeTelecom.Modules.UserAccess.Domain.Users;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly UserAccessContext _userAccessContext;

        public UserRepository(UserAccessContext userAccessContext)
        {
            _userAccessContext = userAccessContext;
        }

        public Task<User> GetByIdAsync(UserId userId)
        {
            return _userAccessContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public Task AddAsync(User user)
        {
            _userAccessContext.AddAsync(user);
            return Task.CompletedTask;
        }
    }
}
