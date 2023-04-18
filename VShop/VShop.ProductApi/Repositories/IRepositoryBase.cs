using System.Linq.Expressions;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(Guid id);
    Task<TEntity?> GetById(Guid id);
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null);
}