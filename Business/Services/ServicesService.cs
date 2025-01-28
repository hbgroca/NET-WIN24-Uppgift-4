using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services
{
    public class ServicesService(IServiceRepositrory repositrory) : IServicesService
    {
        private readonly IServiceRepositrory _serviceRepositrory = repositrory;

        // Create
        public async Task<Service> CreateAsync(ServiceRegistrationForm form)
        {
            // Remap to entity
            ServiceEntity entity = ServiceFactory.Create(form);

            // Add to db
            var result = await _serviceRepositrory.CreateAsync(entity);

            if (result != null)
                return ServiceFactory.Create(result);
            return null!;
        }

        // Read
        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            // Get entities from db
            var services = await _serviceRepositrory.GetAllAsync();

            // Remap to models and save to list
            IEnumerable<Service> list = services.Select(ServiceFactory.Create);

            return list;
        }

        // Update
        public async Task<Service> Update(Service service)
        {
            // Remap to entity
            ServiceEntity entity = ServiceFactory.Create(service);
            // Update in db
            ServiceEntity result = await _serviceRepositrory.UpdateAsync(x => x.Id == entity.Id, entity);
            if (result != null)
            {
                return ServiceFactory.Create(result);
            }

            return null!;
        }

        // Delete
        public async Task<bool> Delete(Service service)
        {
            return await _serviceRepositrory.DeleteAsync(x => x.Id == service.Id);
        }
    }
}
