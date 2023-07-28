using BookStore.DbOperations;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        private readonly IBookStoreDbContext dbContext;
        public UpdateAuthorCommand(IBookStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Handle()
        {
            var author = dbContext.Authors.Where(b => b.Id == AuthorId).FirstOrDefault();
            if (author == null) throw new InvalidOperationException("Böyle bir yazar bulunamadı");
            author.Name = Model.Name;
            author.Surname = Model.Surname;
            author.DateOfBirth = Model.DateOfBirth;
            dbContext.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
