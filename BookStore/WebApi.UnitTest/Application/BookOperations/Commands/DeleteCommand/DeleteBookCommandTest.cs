using AutoMapper;
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

namespace WebApi.UnitTest.Application.BookOperations.Commands.DeleteCommand
{
    public class DeleteBookCommandTest:IClassFixture<CommonTextFixture>
    {

        private readonly BookStoreDbContext context;
        public DeleteBookCommandTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var book = new Book() { Title = "Test Verisi", PageCount = 1000, PublishDate = new DateTime(1990, 01, 20), GenreId = 1,Id=4000 };
            context.Remove(book);
            context.SaveChanges();

            DeleteBookCommand command = new DeleteBookCommand(context);
            command.Id = book.Id;

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_BookId_ShouldBeCreated()
        {
            //arrenge
            DeleteBookCommand command = new DeleteBookCommand(context);
            command.Id = 1;
            //act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var book = context.Books.SingleOrDefault(book => book.Id == command.Id);

            //assert
            book.Should().NotBeNull();
        }
    }
}
