using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions
{
    public interface IGetUserPermissionDatabaseQuery
    {
        Task<IEnumerable<UserPermissionDto>> GetUserPermissionsAsync(Guid id);
    }
}