﻿using Business.Dtos;
using Business.Models;
using Data.Entities;
namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity Create(ProjectRegistrationForm form)
    {
        return new ProjectEntity
        {
            ProjectName = form.Name,
            StartDate = form.StartDate,
            EndDate = form.EndDate,
            EmployeeId = form.ManagerId,
            CustomerId = form.CustomerId,
            ServiceId = form.ServiceId,
            ServiceCost = form.ServiceCost,
            StatusId = form.StatusId,
            Description = form.Description,
        };
    }

    public static Project Create(ProjectEntity entity)
    {
        Project _project = new();
        _project.Id = entity.Id;
        _project.Name = entity.ProjectName;
        _project.StatusId = entity.StatusId;
        _project.Description = entity.Description;
        _project.CustomerId = entity.CustomerId;
        _project.ManagerId = entity.EmployeeId;
        _project.StartDate = entity.StartDate;
        _project.EndDate = entity.EndDate;
        _project.ServicesId = entity.ServiceId;
        _project.ServiceCost = entity.ServiceCost;
        _project.Status = StatusFactory.Create(entity.Status);
        _project.Service = ServiceFactory.Create(entity.Service);
        _project.Manager = EmployeeFactory.Create(entity.Employee);
        _project.Customer = CustomerFactory.Create(entity.Customer);
        
        return _project;
    }

    public static ProjectEntity UpdateEntity(Project project, ProjectEntity entity)
    {
        entity.ProjectName = project.Name;
        entity.StartDate = (DateOnly)project.StartDate!;
        entity.EndDate = (DateOnly)project.EndDate!;
        entity.ServiceId = project.ServicesId;
        entity.CustomerId = project.CustomerId;
        entity.EmployeeId = project.ManagerId;
        entity.StatusId = project.StatusId;
        entity.Description = project.Description;
        entity.ServiceCost = project.ServiceCost;

        return entity;
    }
}
