using AutoMapper;
using BookStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetAuthorsQuery(BookStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public List<AuthorViewModel> Handle()
        {
            var authorList = dbContext.Authors.OrderBy(x => x.Id).ToList();
            List<AuthorViewModel> vm = mapper.Map<List<AuthorViewModel>>(authorList);
            return vm;
        }
    }

    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
