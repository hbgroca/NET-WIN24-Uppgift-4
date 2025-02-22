using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectServices(IProjectRepository projectRepository) : IProjectServices
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    // Create
    public async Task<Project> CreateAsync(ProjectRegistrationForm form)
    {
        if (form == null)
            return null!;

        // Begin transaction
        await _projectRepository.BeginTransactionAsync();

        try
        {
            // Remap dto to entity and add to db
            await _projectRepository.CreateAsync(ProjectFactory.Create(form));
            // Save changes
            await _projectRepository.SaveAsync();
            // Commit transaction
            await _projectRepository.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Rollback transaction if error
            await _projectRepository.RollbackTransactionAsync();
            return null!;
        }

        // Get entity from db, would like to use ID instead of name and use Guid set in service.
        // But we need the db to autoincrement the ID for this assignment.
        var project = await _projectRepository.GetAsync(x => x.ProjectName == form.Name);

        return ProjectFactory.Create(project!) ?? null!;
    }
    // Read
    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        // Get entities from db
        var entities = await _projectRepository.GetAllAsync();
        if (entities != null)
        {
            var projects = entities.Select(ProjectFactory.Create);
            return projects;
        }
        else
            return [];
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        // Get entites from db
        var entities = await _projectRepository.GetAllAsync(expression);
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
        var entitiy = await _projectRepository.GetAsync(x => x.Id == id);
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
        // Begin transaction
        await _projectRepository.BeginTransactionAsync();

        try
        {
            // Get entity from db
            var entity = await _projectRepository.GetAsync(x => x.Id == project.Id);
            if (entity == null)
                throw new Exception("Project not found");

            // Remap from project to entity
            var updatedEntity = ProjectFactory.UpdateEntity(project, entity);
            // Update in dbset
            _projectRepository.Update(updatedEntity);
            // Save changes
            var result = await _projectRepository.SaveAsync();
            if (result == 0)
                throw new Exception("Error when saving project");
            // Commit transaction
            await _projectRepository.CommitTransactionAsync();

            var x = await _projectRepository.GetAsync(x => x.Id == project.Id);
            project = ProjectFactory.Create(x!);

            return project;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Rollback transaction if error
            await _projectRepository.RollbackTransactionAsync();
            return null!;
        }
    }

    // Delete
    public async Task<bool> RemoveProject(Project project)
    {
        // Begin transaction
        await _projectRepository.BeginTransactionAsync();

        try
        {
            // Get entity from db
            var entity = await _projectRepository.GetAsync(x => x.Id == project.Id);
            if (entity == null)
                throw new Exception("Project not found");
            // Delete from dbset
            _projectRepository.Delete(entity);
            // Save changes
            await _projectRepository.SaveAsync();
            // Commit transaction
            await _projectRepository.CommitTransactionAsync();

            return true;
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
            // Rollback transaction if error
            await _projectRepository.RollbackTransactionAsync();
            return false;
        }
    }
}
