using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PeTelecom.API.Configuration.Authorization
{
    public class HasPermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public HasPermissionAuthorizationRequirement()
        {
            
        }
    }
}
