using BookStore.DbOperations;
using System;
using System.Linq;

namespace BookStore.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly BookStoreDbContext dbContext;
        public int Id { get; set; }

        public DeleteGenreCommand(BookStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Handle()
        {
            var genre = dbContext.Genres.Where(x => x.Id == Id).FirstOrDefault();
            if (genre == null) throw new InvalidOperationException("Kitap türü bulunamadı");

            dbContext.Genres.Remove(genre);
            dbContext.SaveChanges();
        }

    }
}
