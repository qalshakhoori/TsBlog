namespace TsBlog.ViewModel.Post
{
    /// <summary>
    /// Bowen View Entity Class
    /// </summary>
    public class PostViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        // / Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        // / content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        // / author ID
        /// </summary>
        public string AuthorId { get; set; }
        /// <summary>
        /// Author's Name
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        public string CreatedAt { get; set; }
        /// <summary>
        /// Release time
        /// </summary>
        public string PublishedAt { get; set; }
        /// <summary>
        /// Whether the identity has been deleted
        /// </summary>
        public string IsDeleted { get; set; }
        /// <summary>
        /// Is display allowed?
        /// </summary>
        public bool AllowShow { get; set; }
        /// <summary>
        /// Browsing volume
        /// </summary>
        public int ViewCount { get; set; }
    }
}