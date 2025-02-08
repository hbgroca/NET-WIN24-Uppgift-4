using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business_Test.Services;

public class ServiceService_Test
{
    private readonly DataContext _context;
    private readonly IServiceRepositrory _repository;
    private readonly IServicesService _service;

    public ServiceService_Test()
    {
        // Create new instance of the DbContext
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: $"DB-{Guid.NewGuid()}")
            .Options;

        _context = new DataContext(options);
        _repository = new ServiceRepository(_context);
        _service = new ServicesService(_repository);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnServiceEntity()
    {
        // Arrange
        var service = new ServiceRegistrationForm()
        {
            Name = "Web development",
            PricePerHour = 3500
        };

        // Act
        var result = await _service.CreateAsync(service);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(service.PricePerHour, result.PricePerHour);
    }


    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfServiceEntities()
    {
        // Arrange
        // Add first service
        var service1 = new ServiceEntity()
        {
            ServiceName = "Web development",
            Price = 3500
        };
        await _repository.CreateAsync(service1);

        // Add second service
        var service2 = new ServiceEntity()
        {
            ServiceName = "Mobile development",
            Price = 4500
        };
        await _repository.CreateAsync(service2);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }


    [Fact]
    public async Task UpdateAsync_ShouldReturnUpdatedServiceEntity()
    {
        // Arrange
        // Add service entity
        var service = new ServiceEntity()
        {
            Id = 69,
            ServiceName = "Web development",
            Price = 3500
        };
        await _repository.CreateAsync(service);

        // Create reference model
        var model = new Service()
        {
            Id = 69,
            Name = "Web development",
            PricePerHour = 4000
        };

        // Act
        var result = await _service.Update(model);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(service.Price, result.PricePerHour);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue()
    {
        // Arrange
        // Add service entity
        var service = new ServiceEntity()
        {
            Id = 69,
            ServiceName = "Web development",
            Price = 3500
        };
        await _repository.CreateAsync(service);

        // Create reference model
        var model = new Service()
        {
            Id = 69,
            Name = "Web development",
            PricePerHour = 3500
        };

        // Act
        var result = await _service.Delete(model);

        // Assert
        Assert.True(result);
    }
}
