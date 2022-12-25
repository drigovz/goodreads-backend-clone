using FluentValidation;
using Goodreads.Core.Entities;

namespace Goodreads.Core.Validations;

internal class LiteraryGenreValidation : AbstractValidator<LiteraryGender>
{
    public LiteraryGenreValidation()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.Description).NotNull().NotEmpty();
    }
}