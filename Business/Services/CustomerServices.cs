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


    // Create
    public async Task<Customer> CreateAsync(CustomerRegistrationForm form)
    {
        // Remap
        CustomerEntity entity = CustomerFactory.Create(form);

        // Add to db
        var result = await _customerRepository.CreateAsync(entity);

        if (result != null)
            return CustomerFactory.Create(result);
        return null!;
    }

    // Read
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        // Get customers from db
        var result = await _customerRepository.GetAllAsync();

        if (result != null)
        {
            // Remap to customer model
            var list = result.Select(CustomerFactory.Create);
            return list;
        }

        return [];
    }



    // Update
    public async Task<Customer> Update(Customer customer)
    {
        // Remap to customer entity
        CustomerEntity entity = CustomerFactory.Create(customer);
        // Update the customer in db
        CustomerEntity result = await _customerRepository.UpdateAsync(x=>x.Id == entity.Id ,entity);
        if(result != null)
        {
            // Remap to customer model
            return CustomerFactory.Create(result);
        }

        return null!;
    }

    // Delete
    public async Task<bool> Delete(Customer customer)
    {
        return await _customerRepository.DeleteAsync(x=>x.Id == customer.Id);
    }
}
