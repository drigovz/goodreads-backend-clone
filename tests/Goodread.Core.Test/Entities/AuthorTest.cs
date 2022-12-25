using FluentAssertions;
using Goodread.Core.Test.Builders;
using Xunit;

namespace Goodreads.Core.Test.Entities;

public class AuthorTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_Name(string invalidName)
    {
        var author = AuthorBuilder.New().AuthorWithName(invalidName).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("Name"));
    }
}