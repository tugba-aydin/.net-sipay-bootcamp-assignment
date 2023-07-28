using AutoMapper;
using BookStore.Application.GenreOperations.Commands.CreateGenre;
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

namespace WebApi.UnitTest.Application.GenreOperations.Commands.CreateCommand
{
    public class CreateGenreCommanTest:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public CreateGenreCommanTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
            mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var genre = new Genre() { IsActive = true, Name= "Romance" };
            context.Genres.Add(genre);
            context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(context, mapper);
            command.Model = new CreateGenreModel() { Name=genre.Name };

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            //arrenge
            CreateGenreCommand command = new CreateGenreCommand(context, mapper);
            CreateGenreModel model = new CreateGenreModel() { Name="test"};
            command.Model = model;

            //act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var genre = context.Genres.SingleOrDefault(genre => genre.Name == "test");

            //assert
            genre.Should().NotBeNull();
            genre.Should().Be(model.Name);
        }
    }
}
