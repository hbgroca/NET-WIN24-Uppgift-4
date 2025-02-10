using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services
{
    public class ServicesService(IServiceRepositrory repositrory) : IServicesService
    {
        private readonly IServiceRepositrory _serviceRepositrory = repositrory;

        // Create
        public async Task<Service> CreateAsync(ServiceRegistrationForm form)
        {
            if (form == null)
                return null!;

            // Begin transaction
            await _serviceRepositrory.BeginTransactionAsync();

            try
            {
                // Remap dto to entity and add to db
                await _serviceRepositrory.CreateAsync(ServiceFactory.Create(form));
                // Save changes
                await _serviceRepositrory.SaveAsync();
                // Commit transaction
                await _serviceRepositrory.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // Rollback transaction if error
                await _serviceRepositrory.RollbackTransactionAsync();
                return null!;
            }

            // Get entity from db 
            var entity = await _serviceRepositrory.GetAsync(x => x.ServiceName == form.Name);
            return ServiceFactory.Create(entity!) ?? null!;
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
            // Begin transaction
            await _serviceRepositrory.BeginTransactionAsync();

            try
            {
                // Get entity from db
                var entity = await _serviceRepositrory.GetAsync(x => x.Id == service.Id);
                if (entity == null)
                    throw new Exception("Customer not found");

                // Remap from project to entity
                entity = ServiceFactory.Update(service, entity);
                // Update in dbset
                var result = _serviceRepositrory.Update(entity);
                if (!result)
                    throw new Exception("Error when updating services");
                // Save changes
                await _serviceRepositrory.SaveAsync();
                // Commit transaction
                await _serviceRepositrory.CommitTransactionAsync();

                return service;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // Rollback transaction if error
                await _serviceRepositrory.RollbackTransactionAsync();
                return null!;
            }
        }

        // Delete
        public async Task<bool> Delete(Service service)
        {
            // Begin transaction
            await _serviceRepositrory.BeginTransactionAsync();

            try
            {
                // Get entity from db
                var entity = await _serviceRepositrory.GetAsync(x => x.Id == service.Id);
                if (entity == null)
                    throw new Exception("Service not found");
                // Delete from dbset
                _serviceRepositrory.Delete(entity);
                // Save changes
                await _serviceRepositrory.SaveAsync();
                // Commit transaction
                await _serviceRepositrory.CommitTransactionAsync();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // Rollback transaction if error
                await _serviceRepositrory.RollbackTransactionAsync();
                return false;
            }
        }
    }
}
