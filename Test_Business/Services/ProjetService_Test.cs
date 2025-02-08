using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business_Test.Services;

public class ProjetService_Test
{
    private readonly DataContext _context;
    private readonly IProjectRepository _repository;
    private readonly IProjectServices _service;

    public ProjetService_Test()
    {
        // Create new instance of the DbContext
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: $"DB-{Guid.NewGuid()}")
            .Options;

        _context = new DataContext(options);
        _repository = new ProjectRepository(_context);
        _service = new ProjectServices(_repository);
    }

    // Create a new instance of the ProjectEntity that will be used in the tests
    private readonly ProjectEntity projectEntity = new ProjectEntity
    {
        ProjectName = "Create website for client",
        Description = "Create a website for the client",
        StartDate = new DateOnly(1986, 1, 1),
        EndDate = new DateOnly(2099, 12, 31),
        ServiceCost = 9999,
        EmployeeId = 1,
        Employee = new EmployeeEntity
        {
            Email = "nils@domain.com",
            FirstName = "Nils",
            LastName = "Andersson"
        },
        CustomerId = 1,
        Customer = new CustomerEntity
        {
            Email = "oskar@domain.com",
            FirstName = "Oskar",
            LastName = "Hansson"
        },
        ServiceId = 1,
        Service = new ServiceEntity
        {
            ServiceName = "Web development"
        },
        StatusId = 1,
        Status = new StatusEntity
        {
            StatusDescription = "Ongoing"
        }
    };


    [Fact]
    public async Task CreateAsync_ShouldReturnServiceEntity()
    {
        // Arrange
        var form = new ProjectRegistrationForm()
        {
            Name = "Webpage development",
            Description = "Description",
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1969)),
            ManagerId = 13,
            CustomerId = 69,
            ServiceId = 420,
            ServiceCost = 1600,
            StatusId = 1
        };

        // Act
        var result = await _service.CreateAsync(form);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Project>(result);
        Assert.Equal(form.ServiceId, result.ServicesId);
    }


    [Fact]
    public async Task GetAllProjectsAsync_ShouldReturnListOfProjectsEntities()
    {
        // Arrange
        // Add 20 project entities to db
        for (int i = 1; i < 21; i++)
        {
            var entity = projectEntity;
            entity.Id = i;
            entity.ProjectName = $"Project {i}";
            await _repository.CreateAsync(entity);
        }

        // Act
        var result = await _service.GetAllProjectsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(20, result.Count());
    }

    [Fact]
    public async Task GetAllProjectsAsync_ShouldReturnListWithEntities_WhenUsedWithExpression()
    {
        // Arrange
        // Add 20 project entities to db
        for (int i = 1; i < 21; i++)
        {
            var entity = projectEntity;
            entity.Id = i;
            await _repository.CreateAsync(entity);
        }

        // Act
        var result = await _service.GetAllProjectsAsync(e => e.ProjectName == projectEntity.ProjectName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(20, result.Count());
    }

    [Fact]
    public async Task GetProjectByIdAsync_ShouldReturnEntity()
    {
        // Arrange
        // Add 5 project entities to db
        for (int i = 1; i < 61; i++)
        {
            var entity = projectEntity;
            entity.Id = i;
            entity.ProjectName = $"Project {i}";    
            await _repository.CreateAsync(entity);
        }

        // Act
        var result = await _service.GetProjectByIdAsync(4);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Project 4", result.Name);
    }


    [Fact]
    public async Task UpdateProject_ShouldReturnUpdatedEntity_WhenSuccessfull()
    {
        // Arrange
        // Add service entity
        await _repository.CreateAsync(projectEntity);

        // Create reference model
        var model = new Project()
        {
            Id = 1,
            Name = "Consulting",
            Description = "Description",
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.FromDateTime(DateTime.Today),
            ManagerId = 13,
            CustomerId = 69,
            ServicesId = 420,
            ServiceCost = 1600,
            StatusId = 1
        };

        // Act
        var result = await _service.UpdateProject(model);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(model.Name, result.Name);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue()
    {
        // Arrange
        // Add service entity
        await _repository.CreateAsync(projectEntity);

        // Create reference model
        var model = new Project()
        {
            Id = 1,
            Name = "",
            Description = "",
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.FromDateTime(DateTime.Today),
            ManagerId = 13,
            CustomerId = 69,
            ServicesId = 420,
            ServiceCost = 1600,
            StatusId = 1
        };

        // Act
        var result = await _service.RemoveProject(model);

        // Assert
        Assert.True(result);
    }
}
