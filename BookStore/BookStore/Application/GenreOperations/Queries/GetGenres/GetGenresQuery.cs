using AutoMapper;
using BookStore.Application.BookOperations.GetBooks;
using BookStore.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetGenresQuery(BookStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public List<GenreViewModel> Handle()
        {
            var genreList = dbContext.Genres.OrderBy(x => x.Id).ToList();
            List<GenreViewModel> vm = mapper.Map<List<GenreViewModel>>(genreList);
            return vm;
        }
    }
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
