using Microsoft.EntityFrameworkCore;
using NumberPlateApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NumberPlateApi.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext DbContext)
        {
            this._RepositoryContext = DbContext;
        }
        public IQueryable<T> FindAll()
        {
            return this._RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this._RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
