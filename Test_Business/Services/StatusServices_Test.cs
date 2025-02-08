using Business.Interfaces;
using Business.Services;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business_Test.Services;

public class StatusServices_Test
{
    private readonly DataContext _context;
    private readonly IStatusRepository _repository;
    private readonly IStatusServices _service;

    public StatusServices_Test()
    {
        // Create new instance of the DbContext
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: $"DB-{Guid.NewGuid()}")
            .Options;

        _context = new DataContext(options);
        _repository = new StatusRepository(_context);
        _service = new StatusServices(_repository);
    }


    [Fact]
    public async Task GetAllAsync_ShouldReturnIEnumrableListWithStatusEntities()
    {
        // Arrange
        _context.Add(new StatusEntity { StatusDescription = "Completed" });
        _context.Add(new StatusEntity { StatusDescription = "In progress" });
        _context.Add(new StatusEntity { StatusDescription = "Not Started" });
        _context.SaveChanges();

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());
    }
}
