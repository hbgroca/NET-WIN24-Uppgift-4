
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerServices(ICustomerRepository repository) : ICustomerServices
{
    private readonly ICustomerRepository _customerRepository = repository;

    public async Task<bool> CreateAsync(CustomerRegistrationForm form)
    {
        // Remap
        CustomerEntity entity = CustomerFactory.Create(form);

        // Add to db
        var result = await _customerRepository.CreateAsync(entity);

        if (result != null)
            return true;
        return false;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        // Get customers from db
        var customers = await _customerRepository.GetAllAsync();

        // Remap
        IEnumerable<Customer> customerList = customers.Select(CustomerFactory.Create).ToList();

        return customerList;
    }
}
