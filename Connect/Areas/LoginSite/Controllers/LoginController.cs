namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;

    using Models;
    using ApplicationServices;
    using Helpers;

    public class LoginController : BaseController
    {
        #region Private Members

        private readonly ILoginApplicationService loginApplicationService;
        private readonly ICompanyInfoProvider companyInfoProvider;

        #endregion

        #region Ctor(s)

        public LoginController(ILoginApplicationService loginApplicationService, ICompanyInfoProvider companyInfoProvider)
        {
            this.loginApplicationService = loginApplicationService;
            this.companyInfoProvider = companyInfoProvider;
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
        public ActionResult UserLogin(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var response = loginApplicationService.Execute(user);

                if (!response.DoesUserExists)
                {
                    return new HttpStatusCodeResult(400, "User with this email does not exists.");
                }

                SetAuthenticationCoockie(response.Email);
                CurrentUser.AddParameter("userId", response.UserId);
                CurrentUser.AddParameter("email", user.Email);
                
                return Redirect(Url.Content("~/Dashboard/UserDashboard"));
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            RemoveAuthenticationCoockie();
            CurrentUser.ClearSession();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyLogin(CompanyLogin company)
        {
            if (ModelState.IsValid)
            {
                var response = loginApplicationService.Execute(company);

                if (!response.DoesCompanyExists)
                {
                    return new HttpStatusCodeResult(400, "Company with this name does not exists.");
                }

                SetAuthenticationCoockie(company.CompanyName);
                CurrentUser.AddParameter("companyId", response.CompanyId);

                return Json(new { RedirectUrl = Url.Content("~/Profile/CompanyProfile") });
            }

            return new HttpStatusCodeResult(400, "Please fill all the fields.");
        }

        #endregion
    }
}