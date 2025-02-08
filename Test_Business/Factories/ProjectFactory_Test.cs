using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;

namespace Business_Test.Factories;

public class ProjectFactory_Test
{
    [Fact]
    private void CreateProjectEntityFromDto_ShouldReturnEntity_WhenSuccessfull()
    {
        // Arrange
        ProjectRegistrationForm form = new()
        {
            Name = "Test project",
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(69)),
            ManagerId = 1969,
            CustomerId = 69,
            ServiceId = 69,
            ServiceCost = 69000,
            StatusId = 69,
            Description = "Blääääääärrrmmm"
        };

        // Act
        ProjectEntity projectEntity = ProjectFactory.Create(form);

        // Assert
        Assert.NotNull(projectEntity);
        Assert.Equal(form.Name, projectEntity.ProjectName);
        Assert.Equal(form.StartDate, projectEntity.StartDate);
    }

    [Fact]
    private void CreateProjectModel_ShouldReturnModel_WhenSuccessfull()
    {
        // Arrange
        ProjectEntity entity = new()
        {
            Id = 69,
            ProjectName = "Test project",
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(69)),
            EmployeeId = 1969,
            CustomerId = 69,
            ServiceId = 69,
            ServiceCost = 69000,
            StatusId = 69,
            Description = "Blääääääärrrmmm"
        };
        // Act
        Project project = ProjectFactory.Create(entity);
        // Assert
        Assert.NotNull(project);
        Assert.Equal(entity.Id, project.Id);
        Assert.Equal(entity.ProjectName, project.Name);
        Assert.Equal(entity.StartDate, project.StartDate);
    }

    [Fact]
    private void UpdateProject_ShouldReturnEntity_WhenSupplyingModelAndEntity_ShouldReturnEntitySuccessfull()
    {
        // Arrange
        ProjectEntity entity = new()
        {
            Id = 69,
            ProjectName = "Test 1",
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(69)),
            EmployeeId = 1969,
            CustomerId = 69,
            ServiceId = 69,
            ServiceCost = 69000,
            StatusId = 69,
            Description = "Blääääääärrrmmm"
        };
        Project project = new()
        {
            Id = 69,
            Name = "Test 2",
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(69)),
            ManagerId = 2004,
            CustomerId = 1,
            ServicesId = 4,
            ServiceCost = 500,
            StatusId = 8,
            Description = "Muuuuh"
        };

        // Act
        ProjectEntity updatedEntity = ProjectFactory.UpdateEntity(project, entity);

        // Assert
        Assert.NotNull(updatedEntity);
        Assert.Equal(project.Name, updatedEntity.ProjectName);
        Assert.Equal(project.StartDate, updatedEntity.StartDate);
    }
}
