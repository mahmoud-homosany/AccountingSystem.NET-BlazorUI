using ApplicationLayer.Contract;
using EContext;
using EContext.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class GenericRepo<TEntity, TId> : IGenericReposatiry<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        private readonly TContext _Context;
        private readonly DbSet<TEntity> dbSet;
        public GenericRepo(TContext context)
        {
            _Context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity Entity)
        {
            return (await dbSet.AddAsync(Entity)).Entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity Entity)
        {
            return await Task.FromResult(_Context.Remove(Entity).Entity);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(dbSet);
        }

        public async ValueTask<TEntity> GetOneAsync(TId Id)
        {
            return await dbSet.FindAsync(Id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _Context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity Entity)
        {
            return await Task.FromResult(dbSet.Update(Entity).Entity);
        }

    }
}
