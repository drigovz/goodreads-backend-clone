using Goodreads.Infra.Data.Repository.Authors;

namespace Goodreads.Infra.Data.Test.Repository;

public class AuthorRepositoryTest
{
    private readonly Mock<AppDbContext> _dbContextMock;
    private readonly Mock<DbSet<Author>> _dbSetMock;
    private readonly Author _author;

    public AuthorRepositoryTest()
    {
        _author = AuthorBuilder.New().Build();
        _author.Id = Guid.NewGuid();
        _dbContextMock = new Mock<AppDbContext>();
        _dbSetMock = new Mock<DbSet<Author>>();
    }

    [Fact]
    [Trait("Infra.Data", "Author")]
    public void Should_Add_New_Author_With_AddAsync()
    {
        // Arrrange
        _dbSetMock.Setup(_ => _.AddAsync(_author, new CancellationToken()));
        _dbContextMock.Setup(_ => _.Set<Author>()).Returns(_dbSetMock.Object);

        // Act
        var authorRepository = new AuthorRepository(_dbContextMock.Object);
        var authorResult = authorRepository.AddAsync(_author).Result;

        // Assert
        authorResult.Should().NotBeNull();
        authorResult.Should().BeAssignableTo<Author>();
        authorResult.Id.Should().Be(_author.Id);
        authorResult.Name.Should().Be(_author.Name);
        authorResult.City.Should().Be(_author.City);
        authorResult.State.Should().Be(_author.State);
        authorResult.Country.Should().Be(_author.Country);
        authorResult.Website.Should().Be(_author.Website);
        authorResult.Description.Should().Be(_author.Description);
        authorResult.Gender.Should().Be(_author.Gender);
    }

    [Fact]
    [Trait("Infra.Data", "Author")]
    public void Should_Execute_GetByIdAsync_And_Returns_Author()
    {
        _dbSetMock.Setup(s => s.FindAsync(It.IsAny<Guid>())).ReturnsAsync(_author);
        _dbContextMock.Setup(_ => _.Set<Author>()).Returns(_dbSetMock.Object);

        var authorRepository = new AuthorRepository(_dbContextMock.Object);
        var authorResult = authorRepository.GetByIdAsync(_author.Id).Result;

        authorResult.Should().NotBeNull();
        authorResult.Should().BeAssignableTo<Author>();
        authorResult.Id.Should().Be(_author.Id);
        authorResult.Name.Should().Be(_author.Name);
        authorResult.City.Should().Be(_author.City);
        authorResult.State.Should().Be(_author.State);
        authorResult.Country.Should().Be(_author.Country);
        authorResult.Website.Should().Be(_author.Website);
        authorResult.Description.Should().Be(_author.Description);
        authorResult.Gender.Should().Be(_author.Gender);
    }
}