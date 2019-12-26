using System.Collections.Generic;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    public interface IPostRepository
    {
        /// <summary>
        /// Query individual data based on ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        Post FindById(int id);
        /// <summary>
        /// Query all data (no pagination, use cautiously in large quantities)
        /// </summary>
        /// <returns></returns>
        IEnumerable<Post> FindAll();

        /// <summary>
        /// Write Entity Data
        /// </summary>
        /// <param name="entity">blog entity class </param>
        /// <returns></returns>
        int Insert(Post entity);

        /// <summary>
        /// Updating Entity Data
        /// </summary>
        /// <param name="entity">blog entity class </param>
        /// <returns></returns>
        bool Update(Post entity);

        /// <summary>
        /// Delete a data by entity
        /// </summary>
        /// <param name="entity">blog entity class </param>
        /// <returns></returns>
        bool Delete(Post entity);

        /// <summary>
        /// Delete the data for the specified ID
        /// </summary>
        /// <param name="id">primary key ID</param>
        /// <returns></returns>
        bool DeleteById(object id);

        /// <summary>
        /// Delete data from the specified ID collection (batch deletion)
        /// </summary>
        /// <param name="ids">primary key ID set </param>
        /// <returns></returns>
        bool DeleteByIds(object[] ids);
    }
}