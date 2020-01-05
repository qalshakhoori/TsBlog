using System.Web.Mvc;
using TsBlog.AutoMapperConfig;
using TsBlog.Services;

namespace TsBlog.Frontend.Controllers
{
    public class PostController : Controller
    {
        /// <summary>
        /// Article Service Interface
        /// </summary>
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Details of the article
        /// </summary>
        /// <param name="id">article ID</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var post = _postService.FindById(id);
            var model = post.ToModel();
            return View(model);
        }
    }
}