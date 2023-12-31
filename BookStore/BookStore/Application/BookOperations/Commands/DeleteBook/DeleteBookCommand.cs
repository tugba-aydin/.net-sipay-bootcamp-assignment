﻿using BookStore.DbOperations;
using System;
using System.Linq;

namespace BookStore.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext dbContext;
        public int Id { get; set; }

        public DeleteBookCommand(IBookStoreDbContext _dbContext)
        {
                dbContext = _dbContext;
        }

        public void Handle()
        {
            var book =dbContext.Books.Where(x=>x.Id == Id).FirstOrDefault();
            if (book == null) throw new InvalidOperationException("Kitap bulunamadı");

            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
        }

    }
}
