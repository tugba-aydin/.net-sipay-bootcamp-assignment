using FluentValidation;

namespace BookStore.Application.BookOperations.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator() {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
