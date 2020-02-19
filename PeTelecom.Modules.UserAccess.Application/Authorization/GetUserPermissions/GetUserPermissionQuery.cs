using PeTelecom.Modules.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;

namespace PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions
{
    public class GetUserPermissionQuery : QueryBase<List<UserPermissionDto>>
    {
        public Guid UserId { get; }

        protected GetUserPermissionQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
