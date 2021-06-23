using CentralDeApostasApi.ApplicationCore.Interfaces.Repository;
using CentralDeApostasApi.ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeApostasApi.ApplicationCore.Services.Common
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected BaseService(
            IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public TEntity Add(TEntity entity)
        {
            var result = _repository.Add(entity);
            return result;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }
            TEntity entityAffected = await _repository.AddAsync(entity);

            return entityAffected;
        }
        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                return _repository.AddRange(entities);
            }
            catch (Exception e)
            {
                return (IEnumerable<TEntity>)e;
            }
        }
        //public IList<TEntity> BulkInsert(IList<TEntity> entities)
        //{
        //    try
        //    {
        //        return _repository.BulkInsert(entities);
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var entity = _repository.Find(predicate);
                return entity;
            }
            catch (Exception ex)
            {
                return (IEnumerable<TEntity>)ex;
            }
        }
        public TEntity Get(int id)
        {
            return _repository.Get(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            var entities = _repository.GetAll();
            return entities;
        }
        public Task<List<TEntity>> GetAllLisAsync()
        {
            var list = _repository.GetAllLisAsync();
            return list;
        }
        public TEntity Remove(TEntity entity)
        {
            var remove = _repository.Remove(entity);
            return remove;
        }
        public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            var removeRange = _repository.RemoveRange(entities);
            return removeRange;
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = _repository.SingleOrDefault(predicate);
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            var update = _repository.Update(entity);
            return update;
        }
    }
}
