using Business.Dtos;
using Business.Models;

namespace Business.Services
{
    public interface ICustomerServices
    {
        Task<bool> CreateAsync(CustomerRegistrationForm form);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}