using BookStore.Common;
using BookStore.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BookOperations.GetById
{
    public class GetByIdQuery
    {
        public int Id { get; set; }
        private readonly BookStoreDbContext dbContext;
        public GetByIdQuery(BookStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public BookViewModel Handle()
        {
            var book = dbContext.Books.Where(x => x.Id == Id).FirstOrDefault();
            BookViewModel vm = new BookViewModel()
            {
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                PageCount = book.PageCount
            };
            return vm;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}
