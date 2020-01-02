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
        public ActionResult Index()
        {
            // If you are not logged in, jump to the login page
            if (Session["user_account"] == null)
            {
                return RedirectToAction("login", "account");
            }
            return View();
        }

        public ActionResult Post()
        {
            // If you are not logged in, jump to the login page
            if (Session["user_account"] == null)
            {
                return RedirectToAction("login", "account");
            }

            var post = _postService.FindById(1).ToModel();
            return View(post);
        }
    }
}