using Bogus;
using Goodreads.Core.Entities;

namespace Goodread.Core.Test.Builders;

public class LiteraryGenderBuilder
{
    static readonly Faker faker = new();

    private string Title = faker.Name.Random.Word();
    private string Description = faker.Name.Random.Words();

    public static LiteraryGenderBuilder New() => new();

    public LiteraryGenderBuilder LiteraryGenderWithTitle(string title)
    {
        Title = title;
        return this;
    }

    public LiteraryGenderBuilder LiteraryGenderWithDescription(string description)
    {
        Description = description;
        return this;
    }

    public LiteraryGender Build() => new(Title, Description);
}