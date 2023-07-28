using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.UpdateBook;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTest.TestSetup;
using Xunit;

namespace WebApi.UnitTest.Application.BookOperations.Commands.UpdateCommand
{
    public class UpdateBookCommandValidatorTest:IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData("Lord Of The", 0, 0)]
        [InlineData("Lor", 100, 1)]
        [InlineData("Lord", 0, 1)]
        [InlineData("Lord", 100, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int Id, int genreId)
        {
            //arrange
            UpdateBookCommand command = new UpdateBookCommand( null);

            command.Model = new UpdateBookModel() { Title = title, GenreId = genreId };
            command.BookId = Id;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}

