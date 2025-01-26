
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class ProjectServices(IProjectRepository projectRepository) : IProjectServices
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    //public async Task<ProjectEntity> Create(ProjectRegistrationForm form)
    //{
    //    if (form == null)
    //    {
    //        return null!;
    //    }
    //    return new ProjectEntity
    //    {
    //        Name = form.Name,
    //        StartDate = DateTime.Now,
    //        ManagerId = form.ManagerId,
    //        CustomerId = form.CustomerId,
    //        //Status = 
    //    };
    //}

    

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        var entities = await _projectRepository.GetAllAsync();
        if (entities != null)
        {
            var projects = entities.Select(ProjectFactory.Create);
            return projects;
        }
        else
            return [];
    }

    public async Task <Project> GetProjectByIdAsync(int id)
    {
        var entitiy = await _projectRepository.GetAsync(x => x.Id == id);
        if (entitiy != null)
        {
            var projects = ProjectFactory.Create(entitiy);
            return projects;
        }
        else
            return null!;
    }
    //public async Task<IEnumerable<Project>> GetProjectsByCustomerAsync(int customerId)
    //{
    //    var entitiy = await _projectRepository.GetAsync(x => x.CustomerId == customerId);
    //    if (entitiy != null)
    //    {
    //        var projects = ProjectFactory.Create(entitiy);
    //        return projects;
    //    }
    //    else
    //        return null!;
    //}
}
