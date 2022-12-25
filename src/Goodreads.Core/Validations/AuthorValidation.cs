using FluentValidation;
using Goodreads.Core.Entities;

namespace Goodreads.Core.Validations;

public class AuthorValidation : AbstractValidator<Author>
{
    public AuthorValidation()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.City).NotNull().NotEmpty();
        RuleFor(x => x.State).NotNull().NotEmpty();
        RuleFor(x => x.Country).NotNull().NotEmpty();
        RuleFor(x => x.Birthdate).DateTimeValidate();
        RuleFor(x => x.Gender).IsInEnum();
    }
}