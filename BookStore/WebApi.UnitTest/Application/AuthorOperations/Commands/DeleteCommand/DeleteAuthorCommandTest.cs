using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.DeleteAuthor;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.DeleteBook;
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

namespace WebApi.UnitTest.Application.AuthorOperations.Commands.DeleteCommand
{
    public class DeleteAuthorCommandTest:IClassFixture<CommonTextFixture>
    {

        private readonly BookStoreDbContext context;
        public DeleteAuthorCommandTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistAuthorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var author = new Author()
            {
                Name = "Randy",
                Surname = "Komisar",
                DateOfBirth = new DateTime(1965, 10, 01)
            };
            context.Remove(author);
            context.SaveChanges();

            DeleteAuthorCommand command = new DeleteAuthorCommand(context);
            command.Id = author.Id;

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_AuthorId_ShouldBeCreated()
        {
            //arrenge
            DeleteAuthorCommand command = new DeleteAuthorCommand(context);
            command.Id = 1;
            //act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var author = context.Authors.SingleOrDefault(author => author.Id == command.Id);

            //assert
            author.Should().NotBeNull();
        }
    }
}
