using System;
using Bogus;
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
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Name"));
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
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("City"));
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
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("State"));
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
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Country"));
    }

    [Fact]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_Birthdate()
    {
        var author = AuthorBuilder.New().AuthorWithBirthdate(DateTime.MinValue).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Birthdate"));
    }

    [Fact]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_Gender()
    {
        var gender = (Gender)100;
        var author = AuthorBuilder.New().AuthorWithGender(gender).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Gender"));
    }

    [Fact]
    [Trait("Domain", "Author")]
    public void Should_Valid_Born_Description()
    {
        Faker faker = new();
        string city = faker.Address.City();
        string state = faker.Address.StateAbbr();
        string country = faker.Address.Country();
        DateTime birthdate = faker.Date.Past(10);

        var author = AuthorBuilder.New()
            .AuthorWithCity(city)
            .AuthorWithState(state)
            .AuthorWithCountry(country)
            .AuthorWithBirthdate(birthdate)
            .Build();

        var bornDesc = author.GetBornDescription();

        author.Valid.Should().BeTrue();
        author.City.Should().Be(city);
        author.State.Should().Be(state);
        author.Country.Should().Be(country);
        author.Birthdate.Should().Be(birthdate);
        bornDesc.Should().Contain(city);
        bornDesc.Should().Contain(state);
        bornDesc.Should().Contain(country);
        bornDesc.Should().Contain($"{birthdate:dd MMMM, yyyy}");
    }
}