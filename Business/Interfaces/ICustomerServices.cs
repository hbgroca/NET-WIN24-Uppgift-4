using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface ICustomerServices
    {
        Task<Customer> CreateAsync(CustomerRegistrationForm form);
        Task<bool> Delete(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> Update(Customer customer);
    }
}