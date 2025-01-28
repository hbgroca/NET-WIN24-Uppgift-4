using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ServiceFactory
{
    public static ServiceEntity Create(ServiceRegistrationForm form)
    {
        if (form == null)
            return null!;

        return new ServiceEntity
        {
            ServiceName = form.Name,
            Price = form.PricePerHour
        };
    }
    public static Service Create(ServiceEntity entity)
    {
        if (entity == null)
            return null!;

        return new Service
        {
            Id = entity.Id,
            Name = entity.ServiceName,
            PricePerHour = entity.Price
        };
    }
    public static ServiceEntity Create(Service service)
    {
        if (service == null)
            return null!;

        return new ServiceEntity
        {
            Id = service.Id,
            ServiceName = service.Name,
            Price = service.PricePerHour
        };
    }
}
