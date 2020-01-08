using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Repositories
{
    public abstract class GenericRepository<T> : IDependency, IRepository<T> where T : class, new()
    {
        #region Implementation of IRepository<T>

        /// <summary>
        /// Query individual data based on principal values
        /// </summary>
        /// <param name="pkValue">primary key value </param>
        /// < returns > generic entities </returns >
        public T FindById(object pkValue)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var entity = db.Queryable<T>().InSingle(pkValue);
                return entity;
            }
        }

        /// <summary>
        /// Query all data (no pagination, please use carefully)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll()
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var list = db.Queryable<T>().ToList();
                return list;
            }
        }

        /// <summary>
        /// Query data according to conditions
        /// </summary>
        /// <param name="predicate">conditional expression tree</param>
        /// <param name="orderBy">sort </param>
        /// < returns > generic entity set </returns >
        public IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "")
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var query = db.Queryable<T>().Where(predicate);

                if (!string.IsNullOrEmpty(orderBy))
                    query = query.OrderBy(orderBy);

                return query.ToList();
            }
        }

        /// <summary>
        /// Query Paging Data Based on Conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="page index">current page index </param>
        /// <param name="pageSize">distribution size </param>
        /// <returns></returns>
        public IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderBy = "", int pageIndex = 1, int pageSize = 20)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var totalCount = 0;
                var page = db.Queryable<T>().OrderBy(orderBy).ToPageList(pageIndex, pageSize, ref totalCount);
                var list = new PagedList<T>(page, pageIndex, pageSize, totalCount);
                return list;
            }
        }

        /// <summary>
        /// Query data according to conditions
        /// </summary>
        /// <param name="predicate">conditional expression tree</param>
        /// <returns></returns>
        public T FindByClause(Expression<Func<T, bool>> predicate)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var entity = db.Queryable<T>().First(predicate);
                return entity;
            }
        }

        /// <summary>
        /// Write Entity Data
        /// </summary>
        /// <param name="entity">entity class </param>
        /// <returns></returns>
        public long Insert(T entity)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                // Returns the ID field value of the inserted data
                var i = db.Insertable(entity).ExecuteReturnBigIdentity();
                return i;
            }
        }

        /// <summary>
        /// Updating Entity Data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                // This approach is conditioned on the primary key.
                var i = db.Updateable(entity).ExecuteCommand();
                return i > 0;
            }
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="entity">entity class </param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable(entity).ExecuteCommand();
                return i > 0;
            }
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="where">filter condition </param>
        /// <returns></returns>
        public bool Delete(Expression<Func<T, bool>> @where)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable<T>(@where).ExecuteCommand();
                return i > 0;
            }
        }

        /// <summary>
        /// Delete the data for the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(object id)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable<T>(id).ExecuteCommand();
                return i > 0;
            }
        }

        /// <summary>
        /// Delete data from the specified ID collection (batch deletion)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteByIds(object[] ids)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable<T>().In(ids).ExecuteCommand();
                return i > 0;
            }
        }
        #endregion
    }
}
