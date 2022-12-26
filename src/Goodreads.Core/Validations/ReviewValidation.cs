using FluentValidation;
using Goodreads.Core.Entities;

namespace Goodreads.Core.Validations;

public class ReviewValidation : AbstractValidator<Review>
{
    public ReviewValidation()
    {
        RuleFor(x => x.Comment).NotNull().NotEmpty();
    }
}