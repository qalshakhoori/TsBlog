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
    }
}
