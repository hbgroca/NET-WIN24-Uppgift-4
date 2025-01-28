using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces;
public interface IProjectRepository : IBaseRepository<ProjectEntity>
{
    Task<ProjectEntity> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task<IEnumerable<ProjectEntity>> GetProjectsAsync();
}
