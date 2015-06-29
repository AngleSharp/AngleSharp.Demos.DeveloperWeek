namespace AngleSharp.Demos.DeveloperWeek.Website.Controllers
{
    using AngleSharp.Demos.DeveloperWeek.Website.Models;
    using System.Web.Mvc;
    using System.Web.Security;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogInModel model)
        {
            if (model.User == "User" && model.Password == "secret")
            {
                FormsAuthentication.SetAuthCookie(model.User, false);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public RedirectToRouteResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

        [HttpGet]
        [Authorize]
        public ViewResult Secret()
        {
            return View();
        }
    }
}