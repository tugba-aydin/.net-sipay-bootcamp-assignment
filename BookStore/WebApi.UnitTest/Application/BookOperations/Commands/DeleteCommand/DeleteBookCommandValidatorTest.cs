using BookStore.Application.BookOperations.DeleteBook;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTest.TestSetup;
using Xunit;

namespace WebApi.UnitTest.Application.BookOperations.Commands.DeleteCommand
{
    public class DeleteBookCommandValidatorTest:IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(4)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            //arrange
            DeleteBookCommand command = new DeleteBookCommand(null);

            command.Id = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
