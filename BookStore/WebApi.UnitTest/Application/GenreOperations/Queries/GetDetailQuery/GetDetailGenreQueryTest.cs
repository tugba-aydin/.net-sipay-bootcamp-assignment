using AutoMapper;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using BookStore.DbOperations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTest.TestSetup;
using Xunit;

namespace WebApi.UnitTest.Application.GenreOperations.Queries.GetDetailQuery
{
    public class GetDetailGenreQueryTest:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public GetDetailGenreQueryTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
            mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var id = 0;

            GetGenreDetailQuery query = new GetGenreDetailQuery(context,mapper);
            query.Id = id;

            //act & assert
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_GenreId_ShouldBeCreated()
        {
            //arrenge
            GetGenreDetailQuery query = new GetGenreDetailQuery(context,mapper);
            query.Id = 1;
            //act
            FluentActions
                .Invoking(() => query.Handle()).Invoke();

            var genre = context.Genres.SingleOrDefault(genre => genre.Id == query.Id);

            //assert
            genre.Should().NotBeNull();
        }
    }
}
