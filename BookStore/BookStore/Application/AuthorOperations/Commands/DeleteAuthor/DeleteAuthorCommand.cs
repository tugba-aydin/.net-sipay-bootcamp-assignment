using BookStore.DbOperations;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext dbContext;
        public int Id { get; set; }

        public DeleteAuthorCommand(BookStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Handle()
        {
            var author = dbContext.Authors.Where(x => x.Id == Id).FirstOrDefault();
            if (author == null) throw new InvalidOperationException("Yazar bulunamadı");

            dbContext.Authors.Remove(author);
            dbContext.SaveChanges();
        }

    }
}
