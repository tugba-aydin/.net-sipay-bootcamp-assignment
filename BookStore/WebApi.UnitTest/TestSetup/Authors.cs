using BookStore.DbOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.UnitTest.TestSetup
{
    public static class Authors
    {
        public static void AddAuthor(this BookStoreDbContext context)
        {
            context.Authors.AddRange(new Author
            {
                Name = "Randy",
                Surname = "Komisar",
                DateOfBirth = new DateTime(1965, 10, 01)
            },
                new Author
                {
                    Name = "Frank",
                    Surname = "Herbert",
                    DateOfBirth = new DateTime(1920, 10, 08)
                },
                new Author
                {
                    Name = "Charlotte Perkins",
                    Surname = "Gilman",
                    DateOfBirth = new DateTime(1860, 07, 03)
                }
                );
        }
    }
}
