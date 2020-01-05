using TsBlog.Core;
using TsBlog.ViewModel.Post;

namespace TsBlog.Frontend.Extensions
{
    public static class PostExtension
    {
        /// <summary>
        /// View Entities Formatting Articles
        /// </summary>
        /// <param name="model">article view entity class </param>
        /// <returns></returns>
        public static PostViewModel FormatPostViewModel(this PostViewModel model)
        {
            if (model == null)
            {
                return null;
            }

            model.Summary = model.Content.
                CleanHtml().// Remove all HTML Tags
                TruncateString(200, TruncateOptions.FinishWord | TruncateOptions.AllowLastWordToGoOverMaxLength).
                TruncateString(200, TruncateOptions.FinishWord | TruncateOptions.AllowLastWordToGoOverMaxLength); // TruncateString the specified length as an abstract of the article
            return model;
        }
}
}