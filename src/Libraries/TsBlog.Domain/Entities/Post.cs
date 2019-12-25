using System;

namespace TsBlog.Domain.Entities
{
    public class Post
    {
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