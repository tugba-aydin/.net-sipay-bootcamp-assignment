using AutoMapper;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
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

namespace WebApi.UnitTest.Application.AuthorOperations.Queries.GetDetailQuery
{
    public class GetDetailAuthorQueryTest:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public GetDetailAuthorQueryTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
            mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotExistAuthorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var id = 0;

            GetAuthorDetailQuery query = new GetAuthorDetailQuery(context,mapper);
            query.Id = id;

            //act & assert
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_AuthorId_ShouldBeCreated()
        {
            //arrenge
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(context,mapper);
            query.Id = 1;
            //act
            FluentActions
                .Invoking(() => query.Handle()).Invoke();

            var author = context.Authors.SingleOrDefault(author => author.Id == query.Id);

            //assert
            author.Should().NotBeNull();
        }
    }
}
