namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;

    using Models;
    using ApplicationServices;

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
                registrationApplicationService.Execute(user);
                SetAuthenticationCoockie(user.Email);

                return RedirectToAction("BusinessInfo", "BusinessInfo", new UserBusinessInfo(user.Email, user.Password, user.FirstName, user.LastName, user.ConfirmPassword, user.Gender, true));
            }
            else
            {
                return RedirectToAction("Index", "Home", user);
            }
        }

        #endregion
    }
}