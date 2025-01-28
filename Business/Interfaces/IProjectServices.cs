using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IProjectServices
    {
        Task<Project> Create(ProjectRegistrationForm form);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetProjectsByUserId(int userId);
        Task<bool> RemoveProject(Project project);
        Task<Project> UpdateProject(Project project);
    }
}