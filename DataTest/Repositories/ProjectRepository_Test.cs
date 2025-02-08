using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data_Test.Repositories;

public class ProjectRepository_Test
{
    private readonly DataContext _context;
    private readonly IProjectRepository _projectRepository;

    public ProjectRepository_Test()
    {
        // Create new instance of the DbContext
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: $"DB-{Guid.NewGuid()}")
            .Options;

        // Create new instance of the DataContext and pass the options to the constructor
        _context = new DataContext(options);
        _projectRepository = new ProjectRepository(_context);
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
        Employee = new EmployeeEntity { 
            Email = "nils@domain.com", 
            FirstName = "Nils", 
            LastName = "Andersson" },
        CustomerId = 1,
        Customer = new CustomerEntity { 
            Email = "oskar@domain.com", 
            FirstName = "Oskar", 
            LastName = "Hansson" },
        ServiceId = 1,
        Service = new ServiceEntity { 
            ServiceName = "Web development" },
        StatusId = 1,
        Status = new StatusEntity { 
            StatusDescription = "Ongoing" }
    };

    // Tests
    [Fact]
    public async Task GetProjectsAsync_ShouldReturnEntity_ThatIncludesOtherEntities()
    {
        // Arrange
        _context.Projects.Add(projectEntity);
        await _context.SaveChangesAsync();

        // Act
        var result = await _projectRepository.GetProjectsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("nils@domain.com", projectEntity.Employee.Email);
        Assert.Equal("oskar@domain.com", projectEntity.Customer.Email);
        Assert.Equal("Web development", projectEntity.Service.ServiceName);
        Assert.Equal("Ongoing", projectEntity.Status.StatusDescription);
    }


    [Fact]
    public async Task GetProjectAsync_UseExpression_ShouldReturnEntity_WhenFoundInDB()
    {
        // Arrange
        _context.Projects.Add(projectEntity);
        await _context.SaveChangesAsync();

        // Act
        var result = await _projectRepository.GetProjectAsync(proj => proj.Customer.FirstName == "Oskar");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Oskar", result.Customer.FirstName);
    }
}
