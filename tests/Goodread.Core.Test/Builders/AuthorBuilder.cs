using System;
using Bogus;
using Goodreads.Core.Entities;
using Goodreads.Core.Enums;

namespace Goodread.Core.Test.Builders;

public class AuthorBuilder
{
    static readonly Faker faker = new();

    static Random _random = new();
    private static int _ramdomNumber = _random.Next(110);
    
    private string Name = faker.Person.FullName;
    private string City = faker.Address.City();
    private string State = faker.Address.StateAbbr();
    private string Country = faker.Address.Country();
    private DateTime Birthdate = faker.Date.Past(_ramdomNumber);
    private string Website = faker.Internet.Url();
    private string Description = faker.Random.Words();
    public Gender Gender = faker.PickRandom<Gender>();

    public static AuthorBuilder New() => new();
    
    public AuthorBuilder AuthorWithName(string name)
    {
        Name = name;
        return this;
    }
    
    public AuthorBuilder AuthorWithCity(string city)
    {
        City = city;
        return this;
    }
    
    public AuthorBuilder AuthorWithState(string state)
    {
        State = state;
        return this;
    }
    
    public AuthorBuilder AuthorWithCountry(string country)
    {
        Country = country;
        return this;
    }
    
    public AuthorBuilder AuthorWithBirthdate(DateTime birthdate)
    {
        Birthdate = birthdate;
        return this;
    }
    
    public AuthorBuilder AuthorWithGender(Gender gender)
    {
        Gender = gender;
        return this;
    }

    public Author Build() =>
        new(Name, City, State, Country, Birthdate, Website, Description, Gender);
}