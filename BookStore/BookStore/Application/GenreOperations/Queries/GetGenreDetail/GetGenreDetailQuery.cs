using AutoMapper;
using BookStore.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int Id { get; set; }
        private readonly IBookStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetGenreDetailQuery(IBookStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public GenreDetailViewModel Handle()
        {
            var genre = dbContext.Genres.Where(x => x.Id == Id).FirstOrDefault();
            return mapper.Map<GenreDetailViewModel>(genre);
             
        }
    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
