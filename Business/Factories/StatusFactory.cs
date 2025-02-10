using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusFactory
{
    public static Status Create(StatusEntity entity)
    {
        if(entity == null)
            return null!;

        return new Status
        {
            Id = entity.Id,
            StatusDescription = entity.StatusDescription
        };
    }

    public static StatusEntity Create(Status model)
    {
        if (model == null)
            return null!;

        return new StatusEntity
        {
            Id = model.Id,
            StatusDescription = model.StatusDescription
        };
    }
}
