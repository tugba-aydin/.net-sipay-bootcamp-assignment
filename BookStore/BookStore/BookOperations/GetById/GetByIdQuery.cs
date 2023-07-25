using AutoMapper;
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
        private readonly IMapper mapper;
        public GetByIdQuery(BookStoreDbContext _dbContext,IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = dbContext.Books.Where(x => x.Id == Id).FirstOrDefault();
            BookDetailViewModel vm = mapper.Map<BookDetailViewModel>(book);
            return vm;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}
