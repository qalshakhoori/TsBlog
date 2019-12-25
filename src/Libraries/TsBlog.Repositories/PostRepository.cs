using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    public class PostRepository
    {
        public Post FindById(int id)
        {
            var ds = MySqlHelper.Query("Select * from tb_post Where Id=@Id", new MySqlParameter("@Id", id));
            var entity = ds.Tables[0].ToList<Post>().FirstOrDefault();
            return entity;
        }

        public List<Post> FindAll()
        {
            var ds = MySqlHelper.Query("Select * From tb_posts");
            return ds.Tables[0].ToList<Post>();
        }
    }
}
