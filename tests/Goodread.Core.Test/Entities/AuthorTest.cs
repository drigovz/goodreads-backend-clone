using System;
using FluentAssertions;
using Goodread.Core.Test.Builders;
using Goodreads.Core.Enums;
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
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_City(string invalidCity)
    {
        var author = AuthorBuilder.New().AuthorWithCity(invalidCity).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("City"));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_State(string invalidState)
    {
        var author = AuthorBuilder.New().AuthorWithState(invalidState).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("State"));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_Country(string invalidCountry)
    {
        var author = AuthorBuilder.New().AuthorWithCountry(invalidCountry).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("Country"));
    }
    
    [Fact]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_Birthdate()
    {
        var author = AuthorBuilder.New().AuthorWithBirthdate(DateTime.MinValue).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("Birthdate"));
    }
    
    [Fact]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_Gender()
    {
        var gender = (Gender)100;
        var author = AuthorBuilder.New().AuthorWithGender(gender).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("Gender"));
    }
}