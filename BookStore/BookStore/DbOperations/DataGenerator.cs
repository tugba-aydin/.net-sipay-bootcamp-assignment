using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any()) { return; }

                context.Authors.AddRange(new Author
                {
                    Name = "Randy",Surname="Komisar", DateOfBirth=new DateTime(1965, 10, 01)
                },
                new Author
                {
                    Name = "Frank",Surname="Herbert", DateOfBirth=new DateTime(1920, 10, 08)
                },
                new Author
                {
                    Name= "Charlotte Perkins",Surname= "Gilman",DateOfBirth=new DateTime(1860,07,03)
                }
                );

                context.Genres.AddRange(new Genre
                {
                    Name = "Personal Growth"
                },
                new Genre 
                { 
                    Name = "Scince Fiction" },
                new Genre 
                { 
                    Name = "Romance" }
                );

                context.Books.AddRange(new Book
                {
                    //Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1,
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                },
                new Book
                {
                    //Id = 2,
                    Title = "Herland",
                    GenreId = 2,
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 05, 23)
                },
                new Book
                {
                    //Id = 3,
                    Title = "Dune",
                    GenreId = 2,
                    PageCount = 540,
                    PublishDate = new DateTime(2001, 12, 21)
                }
                );
                context.SaveChanges();
            }
        }
    }
}
