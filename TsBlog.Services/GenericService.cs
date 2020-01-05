using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public abstract class GenericService<T> : IService<T>, IDependency where T : class, new()
    {
        private readonly IRepository<T> _repository;
        protected GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Query individual data based on principal values
        /// </summary>
        /// <param name="pkValue">primary key value </param>
        /// < returns > generic entities </returns >
        public T FindById(object pkValue)
        {
            return _repository.FindById(pkValue);
        }

        /// <summary>
        /// Query all data (no pagination, please use carefully)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        /// <summary>
        /// Query data according to conditions
        /// </summary>
        /// <param name="predicate">conditional expression tree</param>
        /// <param name="orderBy">sort </param>
        /// < returns > generic entity set </returns >
        public IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "")
        {
            return _repository.FindListByClause(predicate, orderBy);
        }

        /// <summary>
        /// Query data according to conditions
        /// </summary>
        /// <param name="predicate">conditional expression tree</param>
        /// <returns></returns>
        public T FindByClause(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindByClause(predicate);
        }

        /// <summary>
        /// Write Entity Data
        /// </summary>
        /// <param name="entity">entity class </param>
        /// <returns></returns>
        public long Insert(T entity)
        {
            return _repository.Insert(entity);
        }

        /// <summary>
        /// Updating Entity Data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="entity">entity class </param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="where">filter condition </param>
        /// <returns></returns>
        public bool Delete(Expression<Func<T, bool>> @where)
        {
            return _repository.Delete(@where);
        }

        /// <summary>
        /// Delete the data for the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(object id)
        {
            return _repository.DeleteById(id);
        }

        /// <summary>
        /// Delete data from the specified ID collection (batch deletion)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteByIds(object[] ids)
        {
            return _repository.DeleteByIds(ids);
        }
    }
}
