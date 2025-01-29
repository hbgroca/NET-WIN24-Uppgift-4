using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    // Create
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            // Store in staging memory
            await _dbSet.AddAsync(entity);
            // Save to DB
            await _context.SaveChangesAsync();
            // Return entity with updated values
            return entity;
        }
        catch
        {
            return null!;
        }
    }


    // Read
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            // Get all values and return as list
            return await _dbSet.ToListAsync();
        }
        catch { 
            return null!;
        }
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
            return null!;
        // Get the first result from db that matches the expression
        var result = await _dbSet.FirstOrDefaultAsync(expression);
        if(result != null)
        {
            return result;
        }
        return null!;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
            return null!;
        // Get the all results from db that matches in expression
        var result = await _dbSet.Where(expression).ToListAsync();
        if (result != null)
        {
            return result;
        }
        return null!;
    }

    // Update
    public async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;
        try
        {
            // Get matching entity from db
            var existingProductEntity = await _dbSet.FirstOrDefaultAsync(expression);
            if (existingProductEntity == null)
                return null!;

            // Update with the new values
            _context.Entry(existingProductEntity).CurrentValues.SetValues(updatedEntity);
            // Save updated entity to db
            await _context.SaveChangesAsync();

            return updatedEntity;
        }
        catch
        {
            return null!;
        }
    }


    // Delete
    public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
            return false;

        try
        {
            // Find the first result from db based on expression
            var existingProductEntity = await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
            if (existingProductEntity == null)
                return false;

            // Remove from db
            _dbSet.Remove(existingProductEntity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }
}