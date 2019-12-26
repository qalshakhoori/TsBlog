using System.Collections.Generic;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    /// <summary>
    /// Database Operating Class of POST Table
    /// </summary>
    public class PostRepository : IPostRepository
    {
        /// <summary>
        /// Query by ID
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <returns></returns>
        public Post FindById(int id)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var entity = db.Queryable<Post>().Single(x => x.Id == id);
                return entity;
            }
        }

        /// <summary>
        /// Query all data (no pagination, use cautiously in large quantities)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> FindAll()
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var list = db.Queryable<Post>().ToList();
                return list;
            }
        }


        /// <summary>
        /// Write Entity Data
        /// </summary>
        /// <param name="entity">blog entity class </param>
        /// <returns></returns>
        public int Insert(Post entity)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Insertable(entity).ExecuteReturnBigIdentity();
                // The I returned is long, and here you can process it according to your business needs.
                return (int)i;
            }
        }

        /// <summary>
        /// Updating Entity Data
        /// </summary>
        /// <param name="entity">blog entity class </param>
        /// <returns></returns>
        public bool Update(Post entity)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                // This approach is conditioned on the primary key.
                var i = db.Updateable(entity).ExecuteCommand();
                return i > 0;
            }
        }

        /// <summary>
        /// Delete a data by entity
        /// </summary>
        /// <param name="entity">blog entity class </param>
        /// <returns></returns>
        public bool Delete(Post entity)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable(entity).ExecuteCommand();
                return i > 0;
            }
        }

        /// <summary>
        /// Delete the data for the specified ID
        /// </summary>
        /// <param name="id">primary key ID</param>
        /// <returns></returns>
        public bool DeleteById(object id)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable<Post>(id).ExecuteCommand();
                return i > 0;
            }
        }

        /// <summary>
        /// Delete data from the specified ID collection (batch deletion)
        /// </summary>
        /// <param name="ids">primary key ID set </param>
        /// <returns></returns>
        public bool DeleteByIds(object[] ids)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var i = db.Deleteable<Post>().In(ids).ExecuteCommand();
                return i > 0;
            }
        }
    }
}