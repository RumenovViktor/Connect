namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;
    using System.Web;

    using Models;
    using ApplicationServices;
    using Helpers;
    using DTOs.Models;
    using System;
    using System.Collections.Generic;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Data.Repository.Implementation;

    public class RegistrationController : BaseController
    {
        #region Members

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
                var existingUser = UserManager.FindByEmail(user.Email);
                var existingUserName = UserManager.FindByName(user.UserName);

                if (existingUser != null || existingUserName != null)
                {
                    return new HttpStatusCodeResult(400, "User with this email already exists.");
                }

                var registeredUser = new User()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Skills = default(IList<Skill>),
                    IsDeleted = default(bool),
                    DateOfCreation = DateTime.UtcNow,
                    CountryId = user.CountryId,
                    UserName = user.UserName
                };

                UserManager.Create(registeredUser, user.Password);

                SignInManager.SignIn(registeredUser, false, false);

                return RedirectToAction("SetUserRole", "Profile", new { userType = user.UserType, Area="" });
            }
            else
            {
                return new HttpStatusCodeResult(400, "Please fill all the fields.");
            }
        }

        #endregion
    }
}