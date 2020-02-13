using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Application.Authentication.Authenticate
{
    public interface IGetUserLoginDatabaseQuery
    {
        Task<UserDto> GetUserByLoginAsync(string login);
    }
}