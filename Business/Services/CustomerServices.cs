using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class CustomerServices(ICustomerRepository repository) : ICustomerServices
{
    private readonly ICustomerRepository _customerRepository = repository;


    // Create
    public async Task<Customer> CreateAsync(CustomerRegistrationForm form)
    {
        if (form == null)
            return null!;

        // Begin transaction
        await _customerRepository.BeginTransactionAsync();

        try
        {
            // Remap dto to entity and add to db
            await _customerRepository.CreateAsync(CustomerFactory.Create(form));
            // Save changes
            await _customerRepository.SaveAsync();
            // Commit transaction
            await _customerRepository.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Rollback transaction if error
            await _customerRepository.RollbackTransactionAsync();
            return null!;
        }

        var customer = await _customerRepository.GetAsync(x => x.Email == form.Email);

        return CustomerFactory.Create(customer!) ?? null!;
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
        // Begin transaction
        await _customerRepository.BeginTransactionAsync();

        try
        {
            // Get entity from db
            var entity = await _customerRepository.GetAsync(x => x.Id == customer.Id);
            if (entity == null)
                throw new Exception("Customer not found");

            // Remap to customer entity
            entity = CustomerFactory.Update(customer, entity);
            // Update in dbset
            var result = _customerRepository.Update(entity);
            if (!result)
                throw new Exception("Error when updating customer");
            // Save changes
            await _customerRepository.SaveAsync();
            // Commit transaction
            await _customerRepository.CommitTransactionAsync();

            return customer;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Rollback transaction if error
            await _customerRepository.RollbackTransactionAsync();
            return null!;
        }
    }

    // Delete
    public async Task<bool> Delete(Customer customer)
    {
        // Begin transaction
        await _customerRepository.BeginTransactionAsync();

        try
        {
            // Get entity from db
            var entity = await _customerRepository.GetAsync(x => x.Id == customer.Id);
            if (entity == null)
                throw new Exception("Customer not found");
            // Delete from dbset
            _customerRepository.Delete(entity);
            // Save changes
            await _customerRepository.SaveAsync();
            // Commit transaction
            await _customerRepository.CommitTransactionAsync();

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Rollback transaction if error
            await _customerRepository.RollbackTransactionAsync();
            return false;
        }
    }
}
