namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;

    using Models;
    using ApplicationServices;

    public class HomeController : BaseController
    {
        private readonly ICommonInfoManager commonInfoReadStore;

        public HomeController(ICommonInfoManager commonInfoReadStore)
        {
            this.commonInfoReadStore = commonInfoReadStore;
        }

        public ActionResult Index()
        {
            var activityArea = commonInfoReadStore.GetActivityArea();
            var registrationLoginViewModel = new UserRegistrationLogin(activityArea);
            return View("~/Areas/LoginSite/Views/Home/Index.cshtml", registrationLoginViewModel);
        }
    }
}