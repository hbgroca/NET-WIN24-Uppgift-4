using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity Create(CustomerRegistrationForm form)
    {
        if (form == null)
            return null!;

        return new CustomerEntity
        {
            CompanyNr = form.OrganisationNumber,
            CompanyName = form.CompanyName,
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.Phone,
        };
    }

    public static Customer Create(CustomerEntity entity)
    {
        if (entity == null)
            return null!;

        return new Customer
        {
            Id = entity.Id,
            OrganisationNumber = entity.CompanyNr,
            CompanyName = entity.CompanyName,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email!,
            Phone = entity.PhoneNumber,
        };
    }

    public static CustomerEntity Create(Customer customer)
    {
        if (customer == null)
            return null!;

        return new CustomerEntity
        {
            Id = customer.Id,
            CompanyNr = customer.OrganisationNumber,
            CompanyName = customer.CompanyName,
            FirstName = customer.FirstName!,
            LastName = customer.LastName!,
            Email = customer.Email!,
            PhoneNumber = customer.Phone,
        };
    }
}
