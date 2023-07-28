using BookStore.DbOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.UnitTest.TestSetup
{
    public static class Genres
    {
        public static void AddGenre(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                new Genre
                {
                Name = "Personal Growth"
                },
                new Genre
                {
                    Name = "Scince Fiction"
                },
                new Genre
                {
                    Name = "Romance"
                }
                );
        }
    }
}
