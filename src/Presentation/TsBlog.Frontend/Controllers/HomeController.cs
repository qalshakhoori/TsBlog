using PagedList;
using System.Linq;
using System.Web.Mvc;
using TsBlog.AutoMapperConfig;
using TsBlog.Frontend.Extensions;
using TsBlog.Services;
using TsBlog.ViewModel.Post;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Article Service Interface
        /// </summary>
        private readonly IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        /// <summary>
        // / home page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            //var list = _postService.FindHomePagePosts();
            // Read paging data and return IPagedList < Post >
            page = page ?? 0;
            var list = _postService.FindPagedList(x => !x.IsDeleted && x.AllowShow, pageIndex: (int)page, pageSize: 10);
            var model = list.Select(x => x.ToModel().FormatPostViewModel());
            ViewBag.Pagination = new StaticPagedList<PostViewModel>(model, list.PageIndex, list.PageSize, list.TotalCount);
            return View(model);
        }
    }
}