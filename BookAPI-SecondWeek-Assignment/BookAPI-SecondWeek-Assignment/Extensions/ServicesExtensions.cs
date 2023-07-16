using BookAPI_SecondWeek_Assignment.Data;
using BookAPI_SecondWeek_Assignment.Repository;
using BookAPI_SecondWeek_Assignment.Services.Abstract;
using BookAPI_SecondWeek_Assignment.Services.Concrete;
using BookAPI_SecondWeek_Assignment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookAPI_SecondWeek_Assignment.Extensions
{
    public static class ServicesExtensions
    {
        //Configured to connect to database
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) => services.AddDbContext<ApplicationContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));
        
        //Implementation of all services was done with DI
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        public static void ConfigureBookServiceManager(this IServiceCollection services) =>
            services.AddScoped<IBookService, BookService>();
        public static void ConfigureFakeBookServiceManager(this IServiceCollection services) =>
            services.AddScoped<IFakeBookService, FakeBookService>();
        public static void ConfigureLoggingServiceManager(this IServiceCollection services) =>
            services.AddTransient<ILoggingService, LoggingService>();
    }
}
