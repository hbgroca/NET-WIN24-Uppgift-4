using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IEmployeeServices
    {
        Task<Employee> CreateAsync(EmployeeRegistrationForm form);
        Task<bool> Delete(Employee employee);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> Update(Employee employee);
    }
}