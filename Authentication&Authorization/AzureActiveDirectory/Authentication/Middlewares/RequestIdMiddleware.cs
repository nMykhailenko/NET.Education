using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Middlewares
{
    public class RequestIdMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var requetId = Guid.NewGuid().ToString();

            // add custom data of request for private use
            if(!context.Request.Headers.ContainsKey("request-id"))
                context.Request.Headers.Add("request-id", requetId);

            // add custom information for public (Web API response).
            if (!context.Response.Headers.ContainsKey("request-id"))
                context.Response.Headers.Add("request-id", requetId);

            await _next(context);

        }
    }
}

