using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public async Task<IEnumerable<ProjectEntity>> GetProjectsAsync()
    {
        return await _context.Projects
            .Include(p => p.Status)   
            .ToListAsync();
    }

    public async Task<ProjectEntity> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        // Method for testing. Wierd bug
        return await _context.Projects
            .Where(expression)
            .Include(p => p.Status)
            .Include(x => x.Employee)
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .FirstOrDefaultAsync();
    }
}
