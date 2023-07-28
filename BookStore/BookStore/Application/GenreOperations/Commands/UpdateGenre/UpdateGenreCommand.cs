using BookStore.DbOperations;
using System;
using System.Linq;

namespace BookStore.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly IBookStoreDbContext dbContext;
        public UpdateGenreCommand(IBookStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Handle()
        {
            var genre = dbContext.Genres.Where(b => b.Id == GenreId).FirstOrDefault();
            if (genre == null) throw new InvalidOperationException("Böyle bir kitap türü bulunamadı");
            genre.IsActive = Model.IsActive;
            genre.Name = Model.Name;
            dbContext.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
