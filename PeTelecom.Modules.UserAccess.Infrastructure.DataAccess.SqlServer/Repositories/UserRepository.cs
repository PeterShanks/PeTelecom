using DomainUser = PeTelecom.Modules.UserAccess.Domain.Users.User;
using DBUser = PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Models.User;
using System.Threading.Tasks;
using PeTelecom.Modules.UserAccess.Domain.Users;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer.Repositories
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
