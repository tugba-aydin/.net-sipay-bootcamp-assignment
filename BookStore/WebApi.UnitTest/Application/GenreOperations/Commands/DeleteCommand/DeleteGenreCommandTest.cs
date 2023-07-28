using BookStore.Application.GenreOperations.Commands.DeleteGenre;
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

namespace WebApi.UnitTest.Application.GenreOperations.Commands.DeleteCommand
{
    public class DeleteGenreCommandTest:IClassFixture<CommonTextFixture>
    {

        private readonly BookStoreDbContext context;
        public DeleteGenreCommandTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var genre = new Genre() { Name=null,IsActive=true };
            context.Remove(genre);
            context.SaveChanges();

            DeleteGenreCommand command = new DeleteGenreCommand(context);
            command.Id = genre.Id;

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_GenreId_ShouldBeCreated()
        {
            //arrenge
            DeleteGenreCommand command = new DeleteGenreCommand(context);
            command.Id = 1;
            //act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var genre = context.Genres.SingleOrDefault(genre => genre.Id == command.Id);

            //assert
            genre.Should().NotBeNull();
        }
    }
}
