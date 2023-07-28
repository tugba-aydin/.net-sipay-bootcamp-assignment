using BookStore.DbOperations;
using System;
using System.Linq;

namespace BookStore.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }
        private readonly IBookStoreDbContext dbContext;
        public UpdateBookCommand(IBookStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Handle()
        {
            var book = dbContext.Books.Where(b => b.Id == BookId).FirstOrDefault();
            if (book == null) throw new InvalidOperationException("Böyle bir kitap bulunamadı");
            book.GenreId = Model.GenreId;
            book.Title = Model.Title;
            dbContext.SaveChanges();
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}
