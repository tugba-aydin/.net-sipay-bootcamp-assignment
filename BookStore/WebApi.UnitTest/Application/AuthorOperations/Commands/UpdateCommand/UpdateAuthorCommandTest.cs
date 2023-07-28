using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.UpdateAuthor;
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

namespace WebApi.UnitTest.Application.AuthorOperations.Commands.UpdateCommand
{
    public class UpdateAuthorCommandTest:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext context;
        public UpdateAuthorCommandTest(CommonTextFixture testFixture)
        {
            context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistAuthorIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var updateAuthor = new UpdateAuthorModel() { Name="test",Surname="",DateOfBirth=new DateTime(0000-00-00) };
            var id = 0;
            var author = context.Authors.Where(x => x.Id == id).FirstOrDefault();
            author.DateOfBirth = updateAuthor.DateOfBirth;
            author.Surname = updateAuthor.Surname;
            author.Name =  updateAuthor.Name;
            context.SaveChanges();

            UpdateAuthorCommand command = new UpdateAuthorCommand(context);
            command.AuthorId = id;

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir yazar bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            //arrenge
            UpdateAuthorCommand command = new UpdateAuthorCommand(context);
            UpdateAuthorModel model = new UpdateAuthorModel() { Name = "test", Surname = "test", DateOfBirth = new DateTime(2010 - 10 - 10) };
            command.Model = model;
            command.AuthorId = 1;

            //act
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var author = context.Authors.SingleOrDefault(author => author.Id == command.AuthorId);

            //assert
            author.Should().NotBeNull();
            author.Surname.Should().Be(command.Model.Surname);
            author.Name.Should().Be(command.Model.Name);
            author.DateOfBirth.Should().Be(command.Model.DateOfBirth);
        }
    }
}
