namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;

    using Models;
    using ApplicationServices;

    public class LoginController : BaseController
    {
        #region Private Members

        private readonly ILoginApplicationService loginApplicationService;

        #endregion

        #region Ctor(s)

        public LoginController(ILoginApplicationService loginApplicationService)
        {
            this.loginApplicationService = loginApplicationService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                loginApplicationService.Execute(user);
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}