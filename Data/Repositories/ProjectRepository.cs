using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        return await _context.Projects
            .Include(p => p.Status)
            .Include(p => p.Status)
            .Include(x => x.Employee)
            .Include(x => x.Customer)
            .ToListAsync();
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        // Method for testing. Wierd bug
        var entity = await _context.Projects
            .Where(expression)
            .Include(p => p.Status)
            .Include(x => x.Employee)
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .FirstOrDefaultAsync();

        return entity ?? null!;
    }
}
