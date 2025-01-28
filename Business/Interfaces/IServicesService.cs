using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IServicesService
    {
        Task<Service> CreateAsync(ServiceRegistrationForm form);
        Task<bool> Delete(Service service);
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service> Update(Service service);
    }
}