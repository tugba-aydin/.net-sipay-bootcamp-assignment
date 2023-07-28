using BookStore.Application.BookOperations.DeleteBook;
using BookStore.Application.BookOperations.GetById;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTest.TestSetup;
using Xunit;

namespace WebApi.UnitTest.Application.BookOperations.Queries.GetDetailQuery
{
    public class GetDetailBookQueryValidatorTest:IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(4)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            //arrange
            GetByIdQuery query = new GetByIdQuery(null,null);

            query.Id = id;
            GetByIdQueryValidator validator = new GetByIdQueryValidator();
            var errors = validator.Validate(query);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
