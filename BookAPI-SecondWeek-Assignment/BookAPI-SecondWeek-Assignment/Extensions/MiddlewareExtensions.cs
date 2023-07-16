using BookAPI_SecondWeek_Assignment.Middleware;

namespace BookAPI_SecondWeek_Assignment.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
