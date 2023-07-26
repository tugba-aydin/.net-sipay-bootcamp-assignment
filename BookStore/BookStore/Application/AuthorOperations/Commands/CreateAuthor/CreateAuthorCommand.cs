using AutoMapper;
using BookStore.DbOperations;
using BookStore.Entities;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;

        public CreateAuthorCommand(BookStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public void Handle()
        {
            var author = dbContext.Authors.Where(b => b.Name == Model.Name && b.Surname==Model.Surname).FirstOrDefault();
            if (author != null) throw new InvalidOperationException("Yazar zaten mevcut");
            author = mapper.Map<Author>(Model);
            dbContext.Authors.Add(author);
            dbContext.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
