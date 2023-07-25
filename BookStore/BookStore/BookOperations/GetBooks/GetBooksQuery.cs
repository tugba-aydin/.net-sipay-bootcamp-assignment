﻿using AutoMapper;
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
        private readonly IMapper mapper;
        public GetBooksQuery(BookStoreDbContext _dbContext,IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public List<BookViewModel> Handle()
        {
            var bookList = dbContext.Books.OrderBy(x => x.Id).ToList();
            List<BookViewModel> vm = mapper.Map<List<BookViewModel>>(bookList);
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
