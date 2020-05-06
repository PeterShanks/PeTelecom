﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PeTelecom.API.Configuration.Authorization
{
    public abstract class AuthorizeAttributeHandler<TRequirement, TAttribute> : AuthorizationHandler<TRequirement>
        where TRequirement : IAuthorizationRequirement
        where TAttribute : Attribute
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TRequirement requirement)
        {
            var attributes = new List<TAttribute>();

            if (context.Resource is AuthorizationFilterContext authorization &&
                authorization.ActionDescriptor is ControllerActionDescriptor actionDescriptor)
            {
                attributes.AddRange(GetAttributes(actionDescriptor.MethodInfo));

                if(!attributes.Any())
                    attributes.AddRange(GetAttributes(actionDescriptor.ControllerTypeInfo.UnderlyingSystemType));
            }

            return HandleRequirementAsync(context, requirement, attributes);
        }

        protected abstract Task HandleRequirementAsync(AuthorizationHandlerContext context, TRequirement requirement,
            List<TAttribute> attributes);

        private IEnumerable<TAttribute> GetAttributes(MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes(typeof(TAttribute), false).Cast<TAttribute>();
        }
    }
}
