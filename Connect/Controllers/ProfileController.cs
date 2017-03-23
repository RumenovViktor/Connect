using System.Web;
using System.Web.Mvc;

using ApplicationServices;
using Connect.Helpers;
using Models;
using Models.Profile;
using Data;
using Microsoft.AspNet.Identity.Owin;
using Data.Repository.Implementation;
using Microsoft.AspNet.Identity;
using System;

namespace Connect.Controllers
{
    public class ProfileController : BaseController
    {
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

        private readonly IUserInfoProvider userInfoProvider;
        private readonly ISkillsApplicationService skillsApplicationService;
        private readonly ICommonInfoManager commonInfoProvider;
        private readonly IProfileApplicationService profileApplicationService;

        public ProfileController(IUserInfoProvider userInfoProvider, ISkillsApplicationService skillsApplicationService, ICommonInfoManager commonInfoProvider, IProfileApplicationService profileApplicationService)
        {
            this.userInfoProvider = userInfoProvider;
            this.skillsApplicationService = skillsApplicationService;
            this.commonInfoProvider = commonInfoProvider;
            this.profileApplicationService = profileApplicationService;
        }

        public ActionResult SetUserRole(UserType userType)
        {
            var userId = User.Identity.GetUserId();

            switch (userType)
            {
                case UserType.Recruiter:
                    UserManager.AddToRole(int.Parse(userId), "Recruiter");
                    break;
                case UserType.Candidate:
                    UserManager.AddToRole(int.Parse(userId), "Candidate");
                    break;
                default:
                    throw new ArgumentException("No such user type");
            }

            return Json(new { RedirectUrl = Url.Content("~/Profile/Profile") }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public new ActionResult Profile()
        {
            var userId = User.Identity.GetUserId();
            var currentUser = userInfoProvider.GetUserProfile(int.Parse(userId));
            return View(currentUser);
        }

        [Authorize]
        [HttpGet]
        public ActionResult NavigationProfileInfo()
        {
            var userId = User.Identity.GetUserId();
            var userDashboardProfile = userInfoProvider.GetUserDashboardProfile(int.Parse(userId));

            return PartialView(userDashboardProfile);
        }

        [Authorize]
        [HttpGet]
        [ChildActionOnly]
        public ActionResult ProfileBasicInfo()
        {
            var userId = User.Identity.GetUserId();
            var currentUser = userInfoProvider.GetBasicUserInfo(int.Parse(userId));

            return PartialView(currentUser);
        }

        [Authorize]
        [HttpGet]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult Qualifications()
        {
            var userId = User.Identity.GetUserId();
            var currentUser = userInfoProvider.GetUserProfile(int.Parse(userId));

            return PartialView(currentUser);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddExperience(ExperienceViewModel experience)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                experience.UserId = int.Parse(userId);
                userInfoProvider.AddExperience(experience);

                return PartialView("Experience", experience);
            }

            return PartialView(experience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPosition(AddPosition newPosition)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                newPosition.UserId = int.Parse(userId);
                var position = profileApplicationService.Execute(newPosition);

                return PartialView("~/Views/Profile/CreatedPosition.cshtml", new CreatedPosition(position.PositionId, position.PositionName));
            }

            return Json(new { error = "Could not create position" }, JsonRequestBehavior.DenyGet);
        }
    }
}