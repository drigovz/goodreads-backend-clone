using FluentAssertions;
using Goodread.Core.Test.Builders;
using Xunit;

namespace Goodreads.Core.Test.Entities;

public class ReviewTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Review")]
    public void Should_Not_Add_Review_With_Invalid_Comment(string invalidComment)
    {
        var review = ReviewBuilder.New().ReviewWithComments(invalidComment).Build();

        review.Valid.Should().BeFalse();
        review.ValidationResult.Errors.Should().NotBeEmpty();
        review.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
        review.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("Comment"));
    }
}