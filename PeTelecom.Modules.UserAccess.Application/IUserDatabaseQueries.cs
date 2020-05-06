using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate;
using PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions;

namespace PeTelecom.Modules.UserAccess.Application
{
    public interface IUserDatabaseQueries
    {
        Task<UserDto> GetUserByLoginAsync(string login);
        Task<IEnumerable<UserPermissionDto>> GetUserPermissionsAsync(Guid id);
    }
}