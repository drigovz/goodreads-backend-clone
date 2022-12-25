using Goodreads.Core.Entities;
using Goodreads.Core.Validations;

namespace Goodreads.Core.Entities;

public sealed class LiteraryGender : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }

    public LiteraryGender(string title, string description)
    {
        EntityValidation(this, new LiteraryGenreValidation());

        Title = title;
        Description = description;
    }

    public LiteraryGender Update(string title, string description)
    {
        Title = title;
        Description = description;

        EntityValidation(this, new LiteraryGenreValidation());

        return this;
    }
}
