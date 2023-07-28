using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
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

namespace WebApi.UnitTest.Application.AuthorOperations.Commands.CreateCommand
{
    public class CreateAuthorCommanTest:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public CreateAuthorCommanTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
            mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistAuthorIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var author = new Author
            {
                Name = "Randy",
                Surname = "Komisar",
                DateOfBirth = new DateTime(1965, 10, 01)
            };
            context.Authors.Add(author);
            context.SaveChanges();

            CreateAuthorCommand command = new CreateAuthorCommand(context, mapper);
            command.Model = new CreateAuthorModel() { Name = author.Name, Surname=author.Surname,DateOfBirth=author.DateOfBirth };

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            //arrenge
            CreateAuthorCommand command = new CreateAuthorCommand(context, mapper);
            CreateAuthorModel model = new CreateAuthorModel
            {
                Name = "Randy",
                Surname = "Komisar",
                DateOfBirth = new DateTime(1965, 10, 01)
            };
            command.Model = model;

            //act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var author = context.Authors.SingleOrDefault(author => author.Name == "test" && author.Surname=="test");

            //assert
            author.Should().NotBeNull();
            author.DateOfBirth.Should().Be(model.DateOfBirth);
            author.Surname.Should().Be(model.Surname);
            author.Name.Should().Be(model.Name);
        }
    }
}
