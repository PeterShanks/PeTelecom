using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Domain.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}
