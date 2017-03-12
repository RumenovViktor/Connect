namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;

    using Models;
    using ApplicationServices;
    using Helpers;
    using System.Net;

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
                    return new HttpStatusCodeResult(400, "User with this email already exists.");
                }

                SetAuthenticationCoockie(user.Email);
                CurrentUser.AddParameter("email", user.Email);

                return Json(new { RedirectUrl = Url.Content("~/BusinessInfo/BusinessInfo") });
            }
            else
            {
                return new HttpStatusCodeResult(400, "Please fill all the fields.");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterComapany(CompanyRegistration companyRegistrationModel)
        {
            if (ModelState.IsValid)
            {
                var company = registrationApplicationService.Execute(companyRegistrationModel);

                if (company.CompanyExists)
                {
                    return new HttpStatusCodeResult(400, "Company with this name already exists.");
                }

                SetAuthenticationCoockie(company.Email);
                CurrentUser.AddParameter("companyId", company.CompanyId);

                return Json(new { RedirectUrl = Url.Content("~/Profile/CompanyProfile") });
            }
            else
            {
                return new HttpStatusCodeResult(400, "Please fill all the fields.");
            }
        }

        #endregion
    }
}