using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;

namespace Business_Test.Factories;

public class EmployeeFactory_Test
{
    [Fact]
    public void Create_WithNullForm_ShouldReturnNull()
    {
        // Arrange
        EmployeeRegistrationForm form = null;
        // Act
        var result = EmployeeFactory.Create(form);
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Create_WithValidForm_ShouldReturnEmployeeEntity()
    {
        // Arrange
        var form = new EmployeeRegistrationForm
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "",
        };

        // Act
        var result = EmployeeFactory.Create(form);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(form.FirstName, result.FirstName);
    }

    [Fact]
    public void Create_WithNullEntity_ShouldReturnNull()
    {
        // Arrange
        EmployeeEntity entity = null;
        // Act
        var result = EmployeeFactory.Create(entity);
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Create_WithValidEntity_ShouldReturnEmployee()
    {
        // Arrange
        var entity = new EmployeeEntity
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "",
        };
        // Act
        var result = EmployeeFactory.Create(entity);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity.Id, result.Id);
    }

    [Fact]
    public void Create_WithNullEmployee_ShouldReturnNull()
    {
        // Arrange
        Employee employee = null;
        // Act
        var result = EmployeeFactory.Create(employee);
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Create_WithValidEmployee_ShouldReturnEmployeeEntity()
    {
        // Arrange
        var employee = new Employee
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "",
        };
        // Act
        var result = EmployeeFactory.Create(employee);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(employee.Id, result.Id);
    }
}
