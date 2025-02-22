using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
        var entity = await _context.Projects
            .Where(expression)
            .Include(p => p.Status)
            .Include(x => x.Employee)
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .FirstOrDefaultAsync();

        return entity ?? null!;
    }


    // Got some help from CoPilot because it would not save the statusid.
    // So we are now forcing it to always save the statusid as its marked as Modified.
    public override bool Update(ProjectEntity entity)
    {
        try
        {
            // Detach existing entity
            var existing = _dbSet.Local.FirstOrDefault(e =>
                _context.Entry(e).Property("Id").CurrentValue.Equals(
                    _context.Entry(entity).Property("Id").CurrentValue));
            if (existing != null)
            {
                _context.Entry(existing).State = EntityState.Detached;
            }

            // Attach and mark as modified
            _context.Entry(entity).State = EntityState.Modified;

            // Ensure StatusId is marked as modified
            _context.Entry(entity).Property("StatusId").IsModified = true;

            // Debug entity state
            var entry = _context.Entry(entity);
            foreach (var property in entry.Properties)
            {
                Debug.WriteLine($"Property: {property.Metadata.Name}, IsModified: {property.IsModified}");
            }

            return true;
        }
        catch
        {
            Debug.WriteLine("Update - Error updating entity");
            return false;
        }
    }
}
