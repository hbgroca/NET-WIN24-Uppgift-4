using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class EmployeeFactory
{
    public static EmployeeEntity Create(EmployeeRegistrationForm form)
    {
        if (form == null)
            return null!;

        return new EmployeeEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            Phone = form.Phone,
        };
    }

    public static Employee Create(EmployeeEntity entity)
    {
        if (entity == null)
            return null!;

        return new Employee
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone,
        };
    }

    public static EmployeeEntity Create(Employee employee)
    {
        if (employee == null)
            return null!;

        return new EmployeeEntity
        {
            Id = employee.Id,
            FirstName = employee.FirstName!,
            LastName = employee.LastName!,
            Email = employee.Email!,
            Phone = employee.Phone,
        };
    }

    public static EmployeeEntity Update(Employee employee, EmployeeEntity entity)
    {
        if (employee == null || entity == null)
            return null!;

        entity.Id = employee.Id;
        entity.FirstName = employee.FirstName!;
        entity.LastName = employee.LastName!;
        entity.Email = employee.Email!;
        entity.Phone = employee.Phone;

        return entity;
    }
}
