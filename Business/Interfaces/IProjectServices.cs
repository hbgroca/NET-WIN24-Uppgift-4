using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface IProjectServices
    {
        Task<Project> CreateAsync(ProjectRegistrationForm form);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllProjectsAsync(Expression<Func<ProjectEntity, bool>> expression);
        Task<bool> RemoveProject(Project project);
        Task<Project> UpdateProject(Project project);
    }
}