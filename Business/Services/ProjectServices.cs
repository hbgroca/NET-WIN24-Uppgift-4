using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectServices(IProjectRepository projectRepository) : IProjectServices
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    // Create
    public async Task<Project> Create(ProjectRegistrationForm form)
    {
        if (form == null)
            return null!;

        // Remap dto to entity and add to db
        ProjectEntity result = await _projectRepository.CreateAsync(ProjectFactory.Create(form));

        if(result != null)
            return ProjectFactory.Create(result);

        return null!;
    }
    // Read
    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        // Get entities from db
        var entities = await _projectRepository.GetProjectsAsync();
        if (entities != null)
        {
            var projects = entities.Select(ProjectFactory.Create);
            return projects;
        }
        else
            return [];
    }











    public async Task<IEnumerable<Project>> GetProjectsByUserId(int userId)
    {
        // Get entites from db
        var entities = await _projectRepository.GetAllAsync(x => x.CustomerId == userId);
        if (entities != null)
        {
            // Remap to models
            var projects = entities.Select(ProjectFactory.Create); ;
            return projects;
        }
        else
            return null!;
    }


















    public async Task <Project> GetProjectByIdAsync(int id)
    {
        // Get entity from db
        var entitiy = await _projectRepository.GetProjectAsync(x => x.Id == id);
        if (entitiy != null)
        {
            // Remap to model
            var project = ProjectFactory.Create(entitiy);
            return project;
        }
        else
            return null!;
    }
    // Update
    public async Task<Project> UpdateProject(Project project)
    {
        // Get entity from db
        var entitiy = await _projectRepository.GetAsync(x => x.Id == project.Id);
        if (entitiy == null)
            return null! ;

        // Remap from project to entity
        ProjectEntity x = ProjectFactory.UpdateEntity(project, entitiy);
        // Update in db
        var result = await _projectRepository.UpdateAsync(e => e.Id == x.Id, x);
        if (result == null)
            return null!;

        return ProjectFactory.Create(result);
    }

    // Delete
    public async Task<bool> RemoveProject(Project project)
    {
        var result = await _projectRepository.DeleteAsync(x => x.Id == project.Id);
        return result;
    }
}
