using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearningPathTracking_V2.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetOne(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> CreateOne(TEntity obj);
        Task<TEntity?> UpdateOne(Expression<Func<TEntity, bool>> predicate, object updateDto);
        Task<TEntity?> DeleteOne(Expression<Func<TEntity, bool>> predicate);
    }
}
