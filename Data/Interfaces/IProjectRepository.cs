using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces;
public interface IProjectRepository : IBaseRepository<ProjectEntity>
{
    new Task<IEnumerable<ProjectEntity>> GetAllAsync();
    new Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression);
    //Task<ProjectEntity> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression);
    //Task<IEnumerable<ProjectEntity>> GetProjectsAsync();
}
