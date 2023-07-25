using AutoMapper;
using BookStore.Common;
using BookStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;

        public CreateBookCommand(BookStoreDbContext _dbContext, IMapper _mapper)
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
