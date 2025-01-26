using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IProjectServices
    {
        //Task<ProjectEntity> Create(ProjectRegistrationForm form);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
    }
}