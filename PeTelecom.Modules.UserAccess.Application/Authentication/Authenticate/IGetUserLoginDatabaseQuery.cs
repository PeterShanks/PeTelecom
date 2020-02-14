using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate
{
    public interface IGetUserLoginDatabaseQuery
    {
        Task<UserDto> GetUserByLoginAsync(string login);
    }
}