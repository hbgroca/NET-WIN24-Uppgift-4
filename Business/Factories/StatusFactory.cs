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
}
