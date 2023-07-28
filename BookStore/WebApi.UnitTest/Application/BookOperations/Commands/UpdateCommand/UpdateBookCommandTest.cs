using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.UpdateBook;
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

namespace WebApi.UnitTest.Application.BookOperations.Commands.UpdateCommand
{
    public class UpdateBookCommandTest:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext context;
        public UpdateBookCommandTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistBookIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var updateBook = new UpdateBookModel() { Title = "Te", GenreId = 0 };
            var id = 0;
            var book = context.Books.Where(x => x.Id == id).FirstOrDefault();
            book.GenreId = updateBook.GenreId;
            book.Title = updateBook.Title;
            context.SaveChanges();

            UpdateBookCommand command = new UpdateBookCommand(context);
            command.BookId = id;

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir kitap bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            //arrenge
            UpdateBookCommand command = new UpdateBookCommand(context);
            UpdateBookModel model = new UpdateBookModel() { Title = "Lord Of The Rings", GenreId = 1 };
            command.Model = model;
            command.BookId = 1;

            //act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var book = context.Books.SingleOrDefault(book => book.Id == command.BookId);

            //assert
            book.Should().NotBeNull();
            book.Id.Should().Be(command.BookId);
            book.Title.Should().Be(model.Title);
            book.GenreId.Should().Be(model.GenreId);
        }
    }
}
