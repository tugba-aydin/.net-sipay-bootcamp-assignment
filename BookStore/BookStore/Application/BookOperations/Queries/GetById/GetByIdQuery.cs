using AutoMapper;
using BookStore.Common;
using BookStore.DbOperations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.BookOperations.GetById
{
    public class GetByIdQuery
    {
        public int Id { get; set; }
        private readonly IBookStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetByIdQuery(IBookStoreDbContext _dbContext,IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = dbContext.Books.Include(x=>x.Genre).Where(x => x.Id == Id).FirstOrDefault();
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
