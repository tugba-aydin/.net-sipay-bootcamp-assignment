using FluentValidation;

namespace BookStore.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
             RuleFor(command=>command.Id).GreaterThan(0);
        }
    }
}
