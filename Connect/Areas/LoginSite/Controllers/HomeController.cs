namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;

    using Models;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var registrationLoginViewModel = new UserRegistrationLogin();
            return View("~/Areas/LoginSite/Views/Home/Index.cshtml", registrationLoginViewModel);
        }
    }
}