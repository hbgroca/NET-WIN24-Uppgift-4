using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business_Test.Services;

public class EmployeeService_Test
{
    private readonly DataContext _context;
    private readonly IEmployeeRepository _repository;
    private readonly IEmployeeServices _service;

    public EmployeeService_Test()
    {
        // Create new instance of the DbContext
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: $"DB-{Guid.NewGuid()}")
            .Options;

        _context = new DataContext(options);
        _repository = new EmployeeRepository(_context);
        _service = new EmployeeServices(_repository);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnEntity()
    {
        // Arrange
        var form = new EmployeeRegistrationForm()
        {
            Email = "roca@dbpdevelop.com",
            FirstName = "Roca",
            LastName = "Boca",
            Phone = "0700123456"
        };

        // Act
        var result = await _service.CreateAsync(form);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(form.Email, result.Email);
    }


    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfEntities()
    {
        // Arrange
        // Add first employee
        var entity1 = new EmployeeEntity()
        {
            FirstName = "Roca",
            LastName = "Boca",
            Email = "roca@boca.loca"
        };
        await _repository.CreateAsync(entity1);

        // Add second employee
        var entity2 = new EmployeeEntity()
        {
            FirstName = "Goca",
            LastName = "Foca",
            Email = "goca@foca.loca"
        };
        await _repository.CreateAsync(entity2);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }


    [Fact]
    public async Task UpdateAsync_ShouldReturnUpdatedEntity()
    {
        // Arrange
        // Add employee entity
        var entity1 = new EmployeeEntity()
        {
            Id = 69,
            FirstName = "Roca",
            LastName = "Boca",
            Email = "roca@boca.loca"
        };
        await _repository.CreateAsync(entity1);

        // Create model
        var model = new Employee()
        {
            Id = 69,
            FirstName = "OCAR",
            LastName = "Boca",
            Email = "roca@boca.loca"
        };

        // Act
        var result = await _service.Update(model);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(model.FirstName, result.FirstName);
    }


    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue_WhenSuccessfull()
    {
        // Arrange
        // Add employee entity
        var entity1 = new EmployeeEntity()
        {
            Id = 69,
            FirstName = "Roca",
            LastName = "Boca",
            Email = "roca@boca.loca"
        };
        await _repository.CreateAsync(entity1);

        // Create model
        var model = new Employee()
        {
            Id = 69,
            FirstName = "OCAR",
            LastName = "Boca",
            Email = "roca@boca.loca"
        };

        // Act
        var result = await _service.Delete(model);

        // Assert
        Assert.True(result);
    }
}