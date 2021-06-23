using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeApostasApi.ApplicationCore.Interfaces.Service
{
    public interface IBaseService<TEntity>
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        //IList<TEntity> BulkInsert(IList<TEntity> entities);
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> GetAllLisAsync();
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Remove(TEntity entity);
        TEntity Add(TEntity entity);
        TEntity Get(int id);
    }
}
