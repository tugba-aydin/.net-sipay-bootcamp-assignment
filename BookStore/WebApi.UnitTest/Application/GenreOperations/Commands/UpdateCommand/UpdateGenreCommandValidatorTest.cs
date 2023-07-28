using BookStore.Application.BookOperations.UpdateBook;
using BookStore.Application.GenreOperations.Commands.UpdateGenre;
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
    public class UpdateGenreCommandValidatorTest:IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData("Lord Of The", true,1)]
        [InlineData("Lor", false,0)]
        [InlineData("", true,-10)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, bool isActve,int id)
        {
            //arrange
            UpdateGenreCommand command = new UpdateGenreCommand( null);

            command.Model = new UpdateGenreModel() { Name = name, IsActive = isActve };
            command.GenreId = id;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}

