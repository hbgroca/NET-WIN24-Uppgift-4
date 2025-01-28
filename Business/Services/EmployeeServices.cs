using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class EmployeeServices(IEmployeeRepository repository) : IEmployeeServices
{
    private readonly IEmployeeRepository _employeeRepository = repository;

    public async Task<Employee> CreateAsync(EmployeeRegistrationForm form)
    {
        // Remap to entity
        EmployeeEntity entity = EmployeeFactory.Create(form);

        // Add to db
        var result = await _employeeRepository.CreateAsync(entity);
        if (result != null)
            return EmployeeFactory.Create(result);

        return null!;
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

    // Update
    public async Task<Employee> Update(Employee employee)
    {
        // Remap to entity
        EmployeeEntity entity = EmployeeFactory.Create(employee);
        //Update in db
        EmployeeEntity result = await _employeeRepository.UpdateAsync(x => x.Id == entity.Id, entity);
        if (result != null)
        {
            return EmployeeFactory.Create(result);
        }

        return null!;
    }

    // Delete
    public async Task<bool> Delete(Employee employee)
    {
        return await _employeeRepository.DeleteAsync(x => x.Id == employee.Id);
    }
}
