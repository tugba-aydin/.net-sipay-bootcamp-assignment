using AutoMapper;
using BookStore.Application.BookOperations.DeleteBook;
using BookStore.Application.BookOperations.GetById;
using BookStore.DbOperations;
using BookStore.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTest.TestSetup;
using Xunit;

namespace WebApi.UnitTest.Application.BookOperations.Queries.GetDetailQuery
{
    public class GetDetailBookQueryTest:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public GetDetailBookQueryTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
            mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var id = 0;

            GetByIdQuery query = new GetByIdQuery(context,mapper);
            query.Id = id;

            //act & assert
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_BookId_ShouldBeCreated()
        {
            //arrenge
            GetByIdQuery query = new GetByIdQuery(context,mapper);
            query.Id = 1;
            //act
            FluentActions
                .Invoking(() => query.Handle()).Invoke();

            var book = context.Books.SingleOrDefault(book => book.Id == query.Id);

            //assert
            book.Should().NotBeNull();
        }
    }
}
