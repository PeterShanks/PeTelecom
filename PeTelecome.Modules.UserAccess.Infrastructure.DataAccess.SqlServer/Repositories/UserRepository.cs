using DomainUser = PeTelecome.Modules.UserAccess.Domain.Users.User;
using DBUser = PeTelecome.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Models.User;
using System.Threading.Tasks;
using PeTelecome.Modules.UserAccess.Domain.Users;

namespace PeTelecome.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Repositories
{
    public class UserRepository: IUserRepository
    {
        public UserRepository()
        {
        }

        public Task AddAsync(DomainUser user)
        {
            return Task.CompletedTask;
        }
    }
}
