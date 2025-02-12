using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface ICustomerServices
    {
        Task<Customer> CreateAsync(CustomerRegistrationForm form);
        Task<bool> Delete(Customer customer);
        Task<bool> Exists(Expression<Func<CustomerEntity, bool>> expression);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> Update(Customer customer);
    }
}