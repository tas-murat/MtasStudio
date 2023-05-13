using Microsoft.EntityFrameworkCore;
using MtasStudio.Application.Interfaces.Repositories;
using MtasStudio.Domain.SeedWork;
using MtasStudio.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MtasDbContext dbContext;

        public GenericRepository(MtasDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork { get; }

        public virtual async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public virtual async Task<List<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.ToListAsync();
        }

        public virtual Task<List<T>> Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            return Get(filter, null, includes);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(i => i.Id == id);
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }
            return await query.Where(expression).FirstOrDefaultAsync();
        }

        public virtual T Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
