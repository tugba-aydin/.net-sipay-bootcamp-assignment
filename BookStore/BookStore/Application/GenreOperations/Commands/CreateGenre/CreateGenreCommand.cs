using AutoMapper;
using BookStore.DbOperations;
using BookStore.Entities;
using System;
using System.Linq;

namespace BookStore.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;

        public CreateGenreCommand(BookStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public void Handle()
        {
            var genre = dbContext.Genres.Where(b => b.Name == Model.Name).FirstOrDefault();
            if (genre != null) throw new InvalidOperationException("Kitap türü zaten mevcut");
            genre=new Genre();
            genre.Name = Model.Name;
            dbContext.Genres.Add(genre);
            dbContext.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
