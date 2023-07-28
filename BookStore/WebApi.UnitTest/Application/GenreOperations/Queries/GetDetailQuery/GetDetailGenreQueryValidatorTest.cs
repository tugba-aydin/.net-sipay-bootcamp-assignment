using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTest.TestSetup;
using Xunit;

namespace WebApi.UnitTest.Application.GenreOperations.Queries.GetDetailQuery
{
    public class GetDetailGenreQueryValidatorTest:IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(4)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            //arrange
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);

            query.Id = id;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var errors = validator.Validate(query);

            //act & assert
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
