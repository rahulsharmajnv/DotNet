using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DIExampleProject.MiddleWare
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;
            _logger.LogInformation($"Request started at {startTime:O}, Path: {context.Request.Path}");

            await _next(context);

            var endTime = DateTime.UtcNow;
            _logger.LogInformation($"Request ended at {endTime:O}, Duration: {(endTime - startTime).TotalMilliseconds} ms");
        }
    }
}