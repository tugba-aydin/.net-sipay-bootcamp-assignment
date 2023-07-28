using BookStore.Application.GenreOperations.Commands.DeleteGenre;
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
    public class DeleteGenreCommandValidatorTest:IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(4)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            //arrange
            DeleteGenreCommand command = new DeleteGenreCommand(null);

            command.Id = id;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
