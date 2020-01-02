using System;
using System.Web.Mvc;
using TsBlog.Core.Security;
using TsBlog.Domain.Entities;
using TsBlog.Services;
using TsBlog.ViewModel.User;

namespace TsBlog.Frontend.Controllers
{
    /// <summary>
    /// User Center Controller
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// User Service Interface
        /// </summary>
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Login page
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Submit login request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            // If the attributes in the view model are not validated, they return to the login page and ask the user to fill in again.
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Query the specified user entity based on the user login name
            var user = _userService.FindByLoginName(model.UserName.Trim());

            // If the user does not exist, carry the error message and return to the login page
            if (user == null)
            {
                ModelState.AddModelError("error_message", "user does not exist");
                return View(model);
            }

            // If the password does not match, carry the error message and return to the login page
            if (user.Password != Encryptor.Md5Hash(model.Password.Trim()))
            {
                ModelState.AddModelError("error_message", "password error, please log in again");
                return View(model);
            }

            // And save the user entity to Session
            Session["user_account"] = user;
            // Jump to Home Page
            return RedirectToAction("index", "home");
        }

        /// <summary>
        /// Registration page
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Submission of registration request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            // If the attributes in the view model are not validated, they go back to the registration page and ask the user to fill in again.
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Create a user entity
            var user = new User
            {
                LoginName = model.UserName,
                Password = Encryptor.Md5Hash(model.Password.Trim()),
                CreatedOn = DateTime.Now
                // Because it is a sample tutorial, other fields are not filled in.
            };
            // Writing User Entity Objects into a Database
            var ret = _userService.Insert(user);

            if (ret <= 0)
            {
                // If registration fails, carry an error message and return to the registration page
                ModelState.AddModelError("error_message", "registration failure");
                return View(model);

            }
            // If the registration is successful, jump to the login page
            return RedirectToAction("login");
        }
    }
}