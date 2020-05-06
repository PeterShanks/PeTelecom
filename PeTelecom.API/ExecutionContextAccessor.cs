using PeTelecom.BuildingBlocks.Application;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PeTelecom.API.Exceptions;

namespace PeTelecom.API
{
    public class ExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid UserId
        {
            get
            {
                if (_httpContextAccessor
                    .HttpContext
                    .User
                    .HasClaim(c => c.Type == ApiConstants.Subject))
                {
                    return Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ApiConstants.Subject));
                }

                throw new UserContextException("User context is not available");
            }
        }

        public Guid CorrelationId
        {
            get
            {
                if(IsAvailable && _httpContextAccessor.HttpContext.Request.Headers.ContainsKey(ApiConstants.CorrelationHeaderKey))
                    return Guid.Parse(_httpContextAccessor.HttpContext.Request.Headers[ApiConstants.CorrelationHeaderKey]);

                throw  new CorrelationException("Http context and correlation id are not available");
            }
        }

        public bool IsAvailable => _httpContextAccessor.HttpContext != null;
    }
}
