using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions;
using PeTelecom.Modules.UserAccess.Application.Contracts;

namespace PeTelecom.API.Configuration.Authorization
{
    public class HasPermissionAuthorizationHandler
    {
        private readonly IUserAccessModule _userAccessModule;

        public HasPermissionAuthorizationHandler(IUserAccessModule userAccessModule)
        {
            _userAccessModule = userAccessModule;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionAuthorizationRequirement requirement)
        {
            var userPermissions = await _userAccessModule.ExecuteQueryAsync(new GetUserPermissionQuery(Guid.Parse(context.User.FindFirstValue("Id"))))

                //if(userPermissions.Any(u => u.Code == ))
        }
    }
}
