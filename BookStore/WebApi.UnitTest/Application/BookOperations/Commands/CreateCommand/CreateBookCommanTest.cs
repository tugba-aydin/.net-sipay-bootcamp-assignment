using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.DbOperations;
using BookStore.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTest.TestSetup;
using Xunit;

namespace WebApi.UnitTest.Application.BookOperations.Commands.CreateCommand
{
    public class CreateBookCommanTest:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public CreateBookCommanTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
            mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var book = new Book() { Title = "Test Verisi", PageCount = 1000, PublishDate = new DateTime(1990, 01, 20), GenreId = 1 };
            context.Books.Add(book);
            context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(context, mapper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            //arrenge
            CreateBookCommand command = new CreateBookCommand(context, mapper);
            CreateBookModel model = new CreateBookModel() { Title = "Lord Of The Rings", PageCount = 1000, PublishDate = new DateTime(1990, 01, 20), GenreId = 1 };
            command.Model = model;

            //act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var book = context.Books.SingleOrDefault(book => book.Title == "Lord Of The Rings");

            //assert
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
        }
    }
}
