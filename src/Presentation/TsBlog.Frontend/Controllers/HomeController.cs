using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TsBlog.Repositories;
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
            return View();
        }

        public ActionResult Post()
        {
            var post = _postService.FindById(1);
            return View(post);
        }
    }
}