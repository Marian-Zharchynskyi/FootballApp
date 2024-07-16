using FootballApp.Core.Context;
using FootballApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Repository.Common
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
       where TEntity : class, IEntity<TKey>
    {
        protected ProjectContext _ctx;

        public Repository(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _ctx.Set<TEntity>().ToListAsync();

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _ctx.Set<TEntity>().AddAsync(entity);
            await SaveAsync();
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            _ctx.Set<TEntity>().Update(entity);
            await SaveAsync();
        }
        public virtual async Task DeleteAsync(TKey id)
        {
            _ctx.Set<TEntity>().Remove(await _ctx.Set<TEntity>().FindAsync(id));
            await SaveAsync();

        }
        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public async Task SaveAsync() => await _ctx.SaveChangesAsync();
    }
}
