using BookAPI_SecondWeek_Assignment.Middleware;

namespace BookAPI_SecondWeek_Assignment.Extensions
{
    public static class MiddlewareExtensions
    {
        //A method extension was written for the use of custom middleware
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
