using AutoMapper;
using BookStore.Common;
using BookStore.DbOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly IBookStoreDbContext dbContext;
        private readonly IMapper mapper;

        public CreateBookCommand(IBookStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public void Handle()
        {
            var book = dbContext.Books.Where(b => b.Title == Model.Title).FirstOrDefault();
            if (book != null) throw new InvalidOperationException("Kitap zaten mevcut");
            book = mapper.Map<Book>(Model);
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}
