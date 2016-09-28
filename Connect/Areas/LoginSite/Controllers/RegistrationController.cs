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

        public RegistrationController()
        {
            registrationApplicationService = new RegistrationApplicationService();
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
                var registeredUser = registrationApplicationService.Execute(user);
                return View(registeredUser); // Redirect to blanks.
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}