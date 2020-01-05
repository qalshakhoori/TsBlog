using SqlSugar;
using System.Collections.Generic;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    /// <summary>
    /// Database Operating Class of POST Table
    /// </summary>
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        /// <summary>
        /// Query Home Page Articles List
        /// </summary>
        /// <param name="limit">the number of records to query </param>
        /// <returns></returns>
        public IEnumerable<Post> FindHomePagePosts(int limit = 20)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var list = db.Queryable<Post>().OrderBy(x => x.Id, OrderByType.Desc).Take(limit).ToList();
                return list;
            }
        }
    }
}