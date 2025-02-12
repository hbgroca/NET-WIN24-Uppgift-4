using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface IEmployeeServices
    {
        Task<Employee> CreateAsync(EmployeeRegistrationForm form);
        Task<bool> Delete(Employee employee);
        Task<bool> Exists(Expression<Func<EmployeeEntity, bool>> expression);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> Update(Employee employee);
    }
}