using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;
public class StatusServices(IStatusRepository repository) : IStatusServices
{
    private readonly IStatusRepository _statusRepository = repository;

    public async Task CreateDefaultAsync()
    {
        // Creates to default values
        StatusEntity entity = new StatusEntity
        {
            StatusDescription = "In Progress"
        };
        await _statusRepository.CreateAsync(entity);
        entity = new StatusEntity
        {
            StatusDescription = "Finished"
        };
        await _statusRepository.CreateAsync(entity);
        entity = new StatusEntity
        {
            StatusDescription = "Not Started"
        };
        await _statusRepository.CreateAsync(entity);
    }

    public async Task<IEnumerable<Status>> GetAllAsync()
    {
        // Get enteties from DB
        var statuses = await _statusRepository.GetAllAsync();

        if(statuses != null)
        {
            // Remap to model and save to list
            IEnumerable<Status> list = statuses.Select(StatusFactory.Create);
            return list;
        }
 
        return [];
    }
}
