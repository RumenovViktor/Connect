namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;

    using Models;
    using ApplicationServices;
    using Helpers;
    using Data;
    using System.Web;
    using Data.Repository.Implementation;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity;
    using System.Linq;

    public class LoginController : BaseController
    {
        #region Private Members

        private readonly ILoginApplicationService loginApplicationService;

        public UserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<UserManager>();
            }
        }

        public SignInManager SignInManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<SignInManager>();
            }
        }

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
        public ActionResult UserLogin(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var exisitingUser = UserManager.FindByEmail(user.Email);
                var isUserInRole = UserManager.IsInRole(exisitingUser.Id, user.UserType.ToString());

                if (!isUserInRole)
                {
                    return new HttpStatusCodeResult(400, "User with this email does not exists.");
                }

                var response = SignInManager.PasswordSignIn(user.Email, user.Password, false, false);

                switch (response)
                {
                    case SignInStatus.Failure:
                        return new HttpStatusCodeResult(400, "User with this email does not exists.");
                    case SignInStatus.Success:
                        return Redirect(Url.Content("~/Dashboard/UserDashboard"));
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            SignInManager.AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}