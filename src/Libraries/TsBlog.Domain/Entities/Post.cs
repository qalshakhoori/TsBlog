using System;
using SqlSugar;

namespace TsBlog.Domain.Entities
{
    [SugarTable("tb_post")]
    public class Post
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool AllowShow { get; set; }
        public int ViewCount { get; set; }
    }
}