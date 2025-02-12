using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class EmployeeServices(IEmployeeRepository repository) : IEmployeeServices
{
    private readonly IEmployeeRepository _employeeRepository = repository;

    public async Task<Employee> CreateAsync(EmployeeRegistrationForm form)
    {
        if (form == null)
            return null!;

        // Begin transaction
        await _employeeRepository.BeginTransactionAsync();

        try
        {
            // Remap dto to entity and add to db
            await _employeeRepository.CreateAsync(EmployeeFactory.Create(form));
            // Save changes
            await _employeeRepository.SaveAsync();
            // Commit transaction
            await _employeeRepository.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Rollback transaction if error
            await _employeeRepository.RollbackTransactionAsync();
            return null!;
        }

        // Get entity from db, would like to use ID instead of name and use Guid set in service.
        // But we need the db to autoincrement the ID for this assignment.
        var entity = await _employeeRepository.GetAsync(x => x.Email == form.Email);

        return EmployeeFactory.Create(entity!) ?? null!;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        // Get customers from db
        var employees = await _employeeRepository.GetAllAsync();

        if(employees == null)
            return [];

        // Remap to model
        IEnumerable<Employee> employeesList = employees.Select(EmployeeFactory.Create);

        return employeesList;
    }

    public async Task<bool> Exists(Expression<Func<EmployeeEntity, bool>> expression)
    {
        var result = await _employeeRepository.ExistInDb(expression);
        return result;
    }

    // Update
    public async Task<Employee> Update(Employee employee)
    {
        // Begin transaction
        await _employeeRepository.BeginTransactionAsync();

        try
        {
            // Get entity from db
            var entity = await _employeeRepository.GetAsync(x => x.Id == employee.Id);
            if (entity == null)
                throw new Exception("Employee not found");

            // Set new values
            entity = EmployeeFactory.Update(employee, entity);

            // Update in dbset
            var result = _employeeRepository.Update(entity);
            if (!result)
                throw new Exception("Error updating employee");

            // Save changes
            await _employeeRepository.SaveAsync();

            // Commit transaction
            await _employeeRepository.CommitTransactionAsync();

            return employee;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Rollback transaction if error
            await _employeeRepository.RollbackTransactionAsync();
            return null!;
        }
    }

    // Delete
    public async Task<bool> Delete(Employee employee)
    {
        // Begin transaction
        await _employeeRepository.BeginTransactionAsync();

        try
        {
            // Get entity from db
            var entity = await _employeeRepository.GetAsync(x => x.Id == employee.Id);
            if (entity == null)
                throw new Exception("Employee not found");

            // Delete from dbset
            _employeeRepository.Delete(entity);
            // Save changes
            await _employeeRepository.SaveAsync();
            // Commit transaction
            await _employeeRepository.CommitTransactionAsync();

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Rollback transaction if error
            await _employeeRepository.RollbackTransactionAsync();
            return false;
        }
    }
}
