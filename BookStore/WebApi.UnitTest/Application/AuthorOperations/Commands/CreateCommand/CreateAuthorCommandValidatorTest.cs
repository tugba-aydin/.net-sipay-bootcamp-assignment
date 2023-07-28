using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.Application.BookOperations.CreateBook;
using FluentAssertions;
using System;
using WebApi.UnitTest.TestSetup;
using Xunit;

namespace WebApi.UnitTest.Application.AuthorOperations.Commands.CreateCommand
{
    public class CreateAuthorCommandValidatorTest:IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData("", "", "1965-10-01")]
        [InlineData("test", "test", "1965-13-01")]
        [InlineData("", "test", "1965-10-01")]


        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, DateTime dateofbirth)
        {
            //arrange
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);

            command.Model = new CreateAuthorModel() { Name=name, Surname=surname ,DateOfBirth = DateTime.Now.AddDays(-10) };
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);

            command.Model = new CreateAuthorModel() { Name="test", Surname="test" ,DateOfBirth = DateTime.Now.AddDays(-10) };
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
