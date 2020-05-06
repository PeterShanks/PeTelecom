using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PeTelecom.API.Configuration.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public string Permission { get; }
        public static string HasPermissionPolicyName = "HasPermission";
        public HasPermissionAttribute(string permission) : base(HasPermissionPolicyName)
        {
            Permission = permission;
        }
    }
}
