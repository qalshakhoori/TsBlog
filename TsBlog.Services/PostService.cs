using System.Collections.Generic;
using TsBlog.Domain.Entities;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public class PostService : GenericService<Post>, IPostService
    {
        private readonly IPostRepository _repo;
        public PostService(IPostRepository repo) : base (repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Query Home Page Articles List
        /// </summary>
        /// <param name="limit">the number of records to query </param>
        /// <returns></returns>
        public IEnumerable<Post> FindHomePagePosts(int limit = 20)
        {
            return _repo.FindHomePagePosts(limit);
        }
    }
}
