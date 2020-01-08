using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    /// <summary>
    /// Service Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T>
    {
        /// <summary>
        /// Query individual data based on principal values
        /// </summary>
        /// <param name="pkValue">primary key value </param>
        /// < returns > generic entities </returns >
        T FindById(object pkValue);

        /// <summary>
        /// Query all data (no pagination, please use carefully)
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// Query data according to conditions
        /// </summary>
        /// <param name="predicate">conditional expression tree</param>
        /// <param name="orderBy">sort </param>
        /// < returns > generic entity set </returns >
        IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "");

        /// <summary>
        /// Query Paging Data Based on Conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="page index">current page index </param>
        /// <param name="pageSize">distribution size </param>
        /// <returns></returns>
        IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderBy = "", int pageIndex = 1, int pageSize = 20);

        /// <summary>
        /// Query data according to conditions
        /// </summary>
        /// <param name="predicate">conditional expression tree</param>
        /// <returns></returns>
        T FindByClause(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Write Entity Data
        /// </summary>
        /// <param name="entity">entity class </param>
        /// <returns></returns>
        long Insert(T entity);

        /// <summary>
        /// Updating Entity Data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="entity">entity class </param>
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="where">filter condition </param>
        /// <returns></returns>
        bool Delete(Expression<Func<T, bool>> @where);

        /// <summary>
        /// Delete the data for the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteById(object id);

        /// <summary>
        /// Delete data from the specified ID collection (batch deletion)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteByIds(object[] ids);
    }
}
