using PeTelecom.Modules.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using PeTelecom.BuildingBlocks.Application.Configuration.Queries;

namespace PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions
{
    public class GetUserPermissionQuery : QueryBase<List<UserPermissionDto>>
    {
        public Guid UserId { get; }

        public GetUserPermissionQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
