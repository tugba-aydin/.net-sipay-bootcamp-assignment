using FluentValidation;

namespace BookStore.BookOperations.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator() {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
