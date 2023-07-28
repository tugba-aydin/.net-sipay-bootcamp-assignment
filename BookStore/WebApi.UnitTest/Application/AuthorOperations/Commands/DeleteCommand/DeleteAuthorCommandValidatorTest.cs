using BookStore.Application.AuthorOperations.Commands.DeleteAuthor;
using BookStore.Application.BookOperations.DeleteBook;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTest.TestSetup;
using Xunit;

namespace WebApi.UnitTest.Application.AuthorOperations.Commands.DeleteCommand
{
    public class DeleteAuthorCommandValidatorTest:IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(4)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            //arrange
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);

            command.Id = id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            var errors = validator.Validate(command);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
