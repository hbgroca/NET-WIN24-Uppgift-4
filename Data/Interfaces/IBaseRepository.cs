using System.Linq.Expressions;

namespace Data.Interfaces;
public interface IBaseRepository<TEntity> where TEntity : class
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task<bool> CreateAsync(TEntity entity);
    Task<int> SaveAsync();
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
    bool Update(TEntity updatedEntity);
    bool Delete(TEntity entity);
}