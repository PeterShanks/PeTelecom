using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Domain.Users
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(UserId userId);
        Task AddAsync(User user);
    }
}
