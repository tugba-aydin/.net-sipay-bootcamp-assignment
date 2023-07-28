using BookStore.Application.GenreOperations.Commands.CreateGenre;
using FluentAssertions;
using System;
using WebApi.UnitTest.TestSetup;
using Xunit;

namespace WebApi.UnitTest.Application.GenreOperations.Commands.CreateCommand
{
    public class CreateGenreCommandValidatorTest:IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData("Lord Of The")]
        [InlineData("")]
        [InlineData("Lor")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            //arrange
            CreateGenreCommand command = new CreateGenreCommand(null, null);

            command.Model = new CreateGenreModel() { Name=name };
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
