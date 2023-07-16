using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI_SecondWeek_Assignment.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Book>Books { get; set; }
    }
}
