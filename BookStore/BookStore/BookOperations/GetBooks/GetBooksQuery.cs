using BookStore.Common;
using BookStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext dbContext;
        public GetBooksQuery(BookStoreDbContext _dbContext)
        {
            dbContext = _dbContext; 
        }
        public List<BookViewModel> Handle()
        {
            var bookList = dbContext.Books.OrderBy(x => x.Id).ToList();
            List<BookViewModel> vm = new List<BookViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BookViewModel(){
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                    PageCount = book.PageCount
                });
            }
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
