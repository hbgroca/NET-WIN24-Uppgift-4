using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;

namespace Business_Test.Factories;

public class CustomerFactory_Test
{
    [Fact]
    public void Create_CustomerRegistrationForm_ReturnsCustomerEntity()
    {
        // Arrange
        var form = new CustomerRegistrationForm
        {
            OrganisationNumber = "1234567890",
            CompanyName = "Test Company",
            FirstName = "John",
            LastName = "Doe",
            Email = "",
        };

        // Act
        var result = CustomerFactory.Create(form);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(form.OrganisationNumber, result.CompanyNr);
        Assert.Equal(form.CompanyName, result.CompanyName);
    }

    [Fact]
    public void Create_CustomerEntity_ReturnsCustomer()
    {
        // Arrange
        var entity = new CustomerEntity
        {
            Id = 1,
            CompanyNr = "1234567890",
            CompanyName = "Test Company",
            FirstName = "John",
            LastName = "Doe",
            Email = "",
            PhoneNumber = "",
        };
        // Act
        var result = CustomerFactory.Create(entity);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity.Id, result.Id);
        Assert.Equal(entity.CompanyNr, result.OrganisationNumber);
        Assert.Equal(entity.CompanyName, result.CompanyName);
    }

    [Fact]
    public void Create_Customer_ReturnsCustomerEntity()
    {
        // Arrange
        var customer = new Customer
        {
            Id = 1,
            OrganisationNumber = "1234567890",
            CompanyName = "Test Company",
            FirstName = "John",
            LastName = "Doe",
            Email = "",
            Phone = "",
        };
        // Act
        var result = CustomerFactory.Create(customer);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(customer.Id, result.Id);
        Assert.Equal(customer.OrganisationNumber, result.CompanyNr);
        Assert.Equal(customer.CompanyName, result.CompanyName);
    }
}
