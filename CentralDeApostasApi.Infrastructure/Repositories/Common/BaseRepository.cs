using CentralDeApostasApi.ApplicationCore.Interfaces.Repository;
using CentralDeApostasApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeApostasApi.Infrastructure.Repositories.Common
{
    public abstract class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly PostgreSqlContext context;
        protected DbSet<TEntity> DbSet;
        public BaseRepository(PostgreSqlContext context)
        {
            this.context = context;
            DbSet = context.Set<TEntity>();
        }
        public virtual TEntity Add(TEntity entity)
        {
            var result = DbSet.Add(entity);
            SaveChanges();
            return result.Entity;
        }
        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
            SaveChanges();
            return entities;
        }
        //public virtual IList<TEntity> BulkInsert(IList<TEntity> entities)
        //{
        //    context.BulkInsert(entities);
        //    SaveChanges();
        //    return entities;
        //}

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        public virtual TEntity Get(int id)
        {
            return DbSet.Find(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
        public virtual TEntity Remove(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            DbSet.Remove(entity);
            SaveChanges();
            return entity;
        }
        public virtual IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
            SaveChanges();
            return entities;
        }
        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }
        public virtual TEntity Update(TEntity entity)
        {
            var entry = context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            SaveChanges();

            return entity;
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }
        public Task<List<TEntity>> GetAllLisAsync()
        {
            var result = DbSet.ToListAsync();

            var teste = result.Result;

            return result;
        }
    }
}
