using Bogus;
using Goodreads.Core.Entities;

namespace Goodread.Core.Test.Builders;

public class ReviewBuilder
{
    static readonly Faker faker = new();

    private string Comment = faker.Lorem.Random.Words(10);
    private int Likes = faker.Random.Int(100);

    public static ReviewBuilder New() => new();

    public ReviewBuilder ReviewWithComments(string comment)
    {
        Comment = comment;
        return this;
    }

    public ReviewBuilder ReviewWithLikes(int likes)
    {
        Likes = likes;
        return this;
    }

    public Review Build() =>
        new Review(Comment, Likes);
}