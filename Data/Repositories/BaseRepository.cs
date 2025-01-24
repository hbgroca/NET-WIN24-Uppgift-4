using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    // Create
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            // Lägg till i stageing del
            await _dbSet.AddAsync(entity);
            // Spara till db
            await _context.SaveChangesAsync();
            // Returera updaterad entity med auto incriment ID
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR CREATING {nameof(TEntity)} ENTITY :: {ex.Message}");
            return null!;
        }
    }


    // Read
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        return await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
    }
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }


    // Update
    public async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;
        try
        {
            // Sök upp data
            var existingProductEntity = await _dbSet.FirstOrDefaultAsync(expression);
            if (existingProductEntity == null)
                return null!;

            // Uppdatera med dom nya värderna.
            _context.Entry(existingProductEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();

            return updatedEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR Updating {nameof(TEntity)} ENTITY :: {ex.Message}");
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
            var existingProductEntity = await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
            if (existingProductEntity == null)
                return false;

            _dbSet.Remove(existingProductEntity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR DELETING PRODUCT ENTITY :: " + ex.Message);
            return false;
        }
    }
}
