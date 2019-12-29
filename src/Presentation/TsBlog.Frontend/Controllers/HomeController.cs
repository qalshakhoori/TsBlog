using System.Web.Mvc;
using TsBlog.AutoMapperConfig;
using TsBlog.Services;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Post()
        {
            var post = _postService.FindById(1).ToModel();
            return View(post);
        }
    }
}