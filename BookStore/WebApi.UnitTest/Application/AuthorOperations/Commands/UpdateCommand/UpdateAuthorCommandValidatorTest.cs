using BookStore.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStore.Application.BookOperations.UpdateBook;
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
    public class UpdateAuthorCommandValidatorTest:IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData("", "", "1965-10-01",0)]
        [InlineData("test", "test", "1965-13-01",1)]
        [InlineData("", "test", "1965-10-01",1)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, DateTime dateofbirth,int id)
        {
            //arrange
            UpdateAuthorCommand command = new UpdateAuthorCommand( null);

            command.Model = new UpdateAuthorModel() { Name = name, Surname = surname, DateOfBirth = DateTime.Now.AddDays(-10) };
            command.AuthorId = id;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}

