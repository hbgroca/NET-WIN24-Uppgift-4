using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business_Test.Services;

public class CustomerServices_Test
{
    private readonly DataContext _context;
    private readonly ICustomerRepository _repository;
    private readonly ICustomerServices _service;

    public CustomerServices_Test()
    {
        // Create new instance of the DbContext
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: $"DB-{Guid.NewGuid()}")
            .Options;

        _context = new DataContext(options);
        _repository = new CustomerRepository(_context);
        _service = new CustomerServices(_repository);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnEntity()
    {
        // Arrange
        var form = new CustomerRegistrationForm()
        {
            CompanyName = "DBP Develop",
            OrganisationNumber = "999888-8899",
            Email = "roca@dbpdevelop.com",
            FirstName = "Roca",
            LastName = "Boca",
            Phone = "0700123456"
        };

        // Act
        var result = await _service.CreateAsync(form);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(form.CompanyName, result.CompanyName);
    }


    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfEntities()
    {
        // Arrange
        // Add first customer
        var customer1 = new CustomerEntity()
        {
            FirstName = "Roca",
            LastName = "Boca",
            Email = "roca@boca.loca"
        };
        await _repository.CreateAsync(customer1);

        // Add second customer
        var customer2 = new CustomerEntity()
        {
            FirstName = "Goca",
            LastName = "Foca",
            Email = "goca@foca.loca"
        };
        await _repository.CreateAsync(customer2);

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
        // Add entity
        var customer1 = new CustomerEntity()
        {
            Id = 69,
            FirstName = "Roca",
            LastName = "Boca",
            Email = "roca@boca.loca"
        };
        await _repository.CreateAsync(customer1);

        // Create model
        var model = new Customer()
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
        // Add entity
        var customer1 = new CustomerEntity()
        {
            Id = 69,
            FirstName = "Roca",
            LastName = "Boca",
            Email = "roca@boca.loca"
        };
        await _repository.CreateAsync(customer1);

        // Create model
        var model = new Customer()
        {
            Id = 69,
            FirstName = "Roca",
            LastName = "Boca",
            Email = "roca@boca.loca"
        };

        // Act
        var result = await _service.Delete(model);

        // Assert
        Assert.True(result);
    }
}
