﻿using MtasStudio.Application.Models;
using MtasStudio.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<PagingResult<T>> GetPagedDataAsync(PagingResponse pagingResponse);
        Task<List<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);
        Task<List<T>> Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetById(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<T> AddAsync(T entity);
        T Update(T entity);
    }
}
