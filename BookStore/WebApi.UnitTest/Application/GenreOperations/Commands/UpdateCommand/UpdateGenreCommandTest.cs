using BookStore.Application.GenreOperations.Commands.UpdateGenre;
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

namespace WebApi.UnitTest.Application.GenreOperations.Commands.UpdateCommand
{
    public class UpdateGenreCommandTest:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext context;
        public UpdateGenreCommandTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistGenreIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var updateGenre = new UpdateGenreModel() { Name = "Te", IsActive = true };
            var id = 0;
            var genre = context.Genres.Where(x => x.Id == id).FirstOrDefault();
            genre.Name = updateGenre.Name;
            genre.IsActive = updateGenre.IsActive;
            context.SaveChanges();

            UpdateGenreCommand command = new UpdateGenreCommand(context);
            command.GenreId = id;

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir kitap bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            //arrenge
            UpdateGenreCommand command = new UpdateGenreCommand(context);
            UpdateGenreModel model = new UpdateGenreModel() { Name= "Scince",IsActive=false };
            command.Model = model;
            command.GenreId = 1;

            //act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var genre = context.Genres.SingleOrDefault(genre => genre.Id == command.GenreId);

            //assert
            genre.Should().NotBeNull();
            genre.Name.Should().Be(command.Model.Name);
            genre.IsActive.Should().Be(command.Model.IsActive);
        }
    }
}
