using System.Collections.Generic;
using TsBlog.Domain.Entities;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public interface IPostService: IDependency, IService<Post>
    {
        /// <summary>
        /// Query Home Page Articles List
        /// </summary>
        /// <param name="limit">the number of records to query </param>
        /// <returns></returns>
        IEnumerable<Post> FindHomePagePosts(int limit = 20);
    }
}