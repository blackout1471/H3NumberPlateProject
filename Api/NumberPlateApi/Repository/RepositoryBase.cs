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
        /// <summary>
        /// Uses entity framework to make a select * query in the db
        /// </summary>
        /// <returns>Everything in table t</returns>
        public IQueryable<T> FindAll()
        {
            return this._RepositoryContext.Set<T>().AsNoTracking();
        }
        /// <summary>
        /// Uses entity framework to make a select * where query in the db
        /// </summary>
        /// <param name="expression">the condition for the where statement</param>
        /// <returns>Objects from db where condition is met</returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        /// <summary>
        /// Uses entity framework to make an insert query in the db
        /// </summary>
        /// <param name="entity">Entity to be inserted into the db</param>
        public void Create(T entity)
        {
            this._RepositoryContext.Set<T>().Add(entity);
        }
        /// <summary>
        /// Uses entity framework to make an update query in the db
        /// </summary>
        /// <param name="entity">Entity to be updated in the db</param>
        public void Update(T entity)
        {
            this._RepositoryContext.Set<T>().Update(entity);
        }
        /// <summary>
        /// Uses entity framework to make a delete query in the db
        /// </summary>
        /// <param name="entity">Entity to be deleted in the db</param>
        public void Delete(T entity)
        {
            this._RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
