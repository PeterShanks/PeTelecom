using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PeTelecom.API.Middlewares
{
    internal class CorrelationMiddleware
    {
        private readonly RequestDelegate _next;

        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var correlationId = Guid.NewGuid();

            context.Request.Headers.Add(ApiConstants.CorrelationHeaderKey, correlationId.ToString());

            await _next(context);
        }
    }
}
