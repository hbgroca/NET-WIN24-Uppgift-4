using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
namespace Business.Factories;

public static class ProjectFactory
{
    public static Project Create(ProjectEntity entity)
    {
        Project _project = new();

        _project.Id = entity.Id;
        _project.Name = entity.ProjectName;
        _project.Description = entity.Description;
        _project.CustomerId = entity.CustomerId;
        _project.Customer = RemapService(entity.Customer);
        _project.ManagerId = entity.ManagerId;
        //_project.Manager = RemapService(entity.Manager);
        _project.StartDate = entity.StartDate;
        _project.EndDate = entity.EndDate;

        List<Service> _services = RemapService(entity.Services);
        _project.Services = _services;


        switch (entity.Status.ToString())
        {
            case "1":
                {
                    _project.Status = "Ej påbörjat";
                    break;
                }
            case "2":
                {
                    _project.Status = "Pågående";
                    break;
                }
            case "3":
                {
                    _project.Status = "Avslutat";
                    break;
                }
        }

        return _project;
    }

    private static List<Service> RemapService(ICollection<ServiceEntity> services)
    {
        if (services == null)
            return [];

        

        List<Service> thelist = new();

        foreach (var service in services)
        {
            Debug.WriteLine($"Remapping service entity: {service.ServiceName}");
            Service _service = new();
            _service.Id = service.Id;
            _service.Name = service.ServiceName;
            _service.Price = service.Price;
            thelist.Add(_service);
        }
        return thelist;
    }


    private static Customer RemapService(CustomerEntity entity)
    {
        if (entity != null)
        {
            Debug.WriteLine($"Remapping customerentity: {entity.FirstName}");
            return new Customer
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CompanyName = entity.CompanyName,
                OrganisationNumber = entity.CompanyNr,
                Email = entity.Email!,
                Phone = entity.PhoneNumber,
            };
        }
        return null!;
    }
    //private static  RemapService(EmployeeEntity entity)
    //{
    //    if (entity != null)
    //    {
    //        Debug.WriteLine($"Remapping customerentity: {entity.FirstName}");
    //        return new Customer
    //        {
    //            Id = entity.Id,
    //            FirstName = entity.FirstName,
    //            LastName = entity.LastName,
    //            CompanyName = entity.CompanyName,
    //            OrganisationNumber = entity.CompanyNr,
    //            Email = entity.Email!,
    //            Phone = entity.PhoneNumber,
    //        };
    //    }
    //    return null!;
    //}
}
