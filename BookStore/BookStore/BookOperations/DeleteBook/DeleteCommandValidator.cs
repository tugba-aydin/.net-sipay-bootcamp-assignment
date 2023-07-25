using FluentValidation;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteCommandValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteCommandValidator()
        {
             RuleFor(command=>command.Id).GreaterThan(0);
        }
    }
}
