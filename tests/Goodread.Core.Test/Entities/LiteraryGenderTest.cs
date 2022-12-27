using FluentAssertions;
using Goodread.Core.Test.Builders;
using Xunit;

namespace Goodreads.Core.Test.Entities;

public class LiteraryGenderTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "LiteraryGender")]
    public void Should_Not_Create_Literary_Gender_With_Invalid_Title(string invalidTitle)
    {
        var literaryGender = LiteraryGenderBuilder.New().LiteraryGenderWithTitle(invalidTitle).Build();

        literaryGender.Valid.Should().BeFalse();
        literaryGender.ValidationResult.Errors.Should().NotBeEmpty();
        literaryGender.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        literaryGender.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Title"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "LiteraryGender")]
    public void Should_Not_Create_Literary_Gender_With_Invalid_Description(string invalidDescription)
    {
        var literaryGender = LiteraryGenderBuilder.New().LiteraryGenderWithDescription(invalidDescription).Build();

        literaryGender.Valid.Should().BeFalse();
        literaryGender.ValidationResult.Errors.Should().NotBeEmpty();
        literaryGender.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        literaryGender.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Description"));
    }
}
