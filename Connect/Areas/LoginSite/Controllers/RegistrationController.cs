namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;

    using Models;
    using ApplicationServices;
    using Helpers;

    public class RegistrationController : BaseController
    {
        #region Private Members

        public readonly IRegistrationApplicationService registrationApplicationService;

        #endregion

        #region Ctor(s)

        public RegistrationController(IRegistrationApplicationService registrationApplicationService)
        {
            this.registrationApplicationService = registrationApplicationService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserRegistration user)
        {
            if (ModelState.IsValid)
            {
                var userExists = registrationApplicationService.Execute(user);

                if (userExists.UserExists)
                {
                    ModelState.AddModelError("", "User already exists with this email.");
                    return RedirectToAction("Index", "Home", user);
                }

                SetAuthenticationCoockie(user.Email);
                CurrentUser.AddParameter("email", user.Email);

                return RedirectToAction("BusinessInfo", "BusinessInfo");
            }
            else
            {
                return RedirectToAction("Index", "Home", user);
            }
        }

        #endregion
    }
}