using PeTelecome.Modules.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeTelecome.Modules.UserAccess.Application.Authorization.GetUserPermissions
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
