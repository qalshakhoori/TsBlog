using System.Collections.Generic;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> FindHomePagePosts(int limit = 20);
    }
}