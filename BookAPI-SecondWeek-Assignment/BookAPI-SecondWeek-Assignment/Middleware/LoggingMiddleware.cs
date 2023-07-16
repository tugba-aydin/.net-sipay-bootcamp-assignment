using BookAPI_SecondWeek_Assignment.Services.Abstract;
using Microsoft.AspNetCore.Diagnostics;

namespace BookAPI_SecondWeek_Assignment.Middleware
{
    public class LoggingMiddleware
    {
        //A custom middleware has been written to do Global Logging.
        private readonly RequestDelegate next;
        private readonly ILoggingService logger;

        public LoggingMiddleware(RequestDelegate _next, ILoggingService _logger)
        {
            next = _next;
            logger = _logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            logger.Start();
            await next(context);
            logger.End();
        }
    }
}
