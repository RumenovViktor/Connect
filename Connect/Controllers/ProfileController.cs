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
            var userName = User.Identity.GetUserName();

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

            return Json(new { RedirectUrl = Url.Content("~/Profile/Profile?userName=" + userName) }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public new ActionResult Profile(string userName)
        {
            var user = UserManager.FindByName(userName);

            var isRecruiter = UserManager.IsInRole(user.Id, "Recruiter");
            var currentUser = userInfoProvider.GetUserProfile(user.Id);

            if (isRecruiter)
            {
                Session["userNameReadOnly"] = userName;
                if (User.Identity.GetUserName().Equals(userName))
                {
                    Session["userName"] = userName;
                    currentUser.CanEditProfile = true;
                    return View("RecruiterProfile");
                }

                return View("RecruiterProfileReadOnly");
            }

            if (User.Identity.GetUserName().Equals(userName))
            {
                Session["userName"] = userName;
                currentUser.CanEditProfile = true;
                return View(currentUser);
            }

            return View("ProfileReadOnly", currentUser);
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
        public ActionResult ProfileBasicInfo(string userName)
        {
            var user = UserManager.FindByName(userName);
            var currentUser = userInfoProvider.GetBasicUserInfo(user.Id);

            if (User.Identity.GetUserName().Equals(userName))
            {
                currentUser.CanEditProfile = true;
            }

            return PartialView(currentUser);
        }

        [Authorize]
        [HttpGet]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult Qualifications(string userName)
        {
            var user = UserManager.FindByName(userName);
            var currentUser = userInfoProvider.GetUserProfile(user.Id);

            if (User.Identity.GetUserName().Equals(userName))
            {
                currentUser.CanEditProfile = true;
            }

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
                userInfoProvider.AddExperience(experience, UserManager);

                return PartialView("Experience", experience);
            }

            return PartialView(experience);
        }

        [Authorize]
        [HttpGet]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult CreatePosition()
        {
            return PartialView("~/Views/RecruiterProfile/AddPosition.cshtml", new AddPosition());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePosition(AddPosition newPosition)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                newPosition.UserId = int.Parse(userId);
                var position = profileApplicationService.Execute(newPosition);

                return Json(position.PositionId, JsonRequestBehavior.AllowGet);
            }

            return Json(new { error = "Could not create position" }, JsonRequestBehavior.DenyGet);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetOpenedPositions(string userName)
        {
            var user = UserManager.FindByName(userName);
            var openedPositions = userInfoProvider.GetCreatedPositions(user.Id);
            return PartialView("~/Views/Dashboard/RecruiterDashboard/CreatedPositions.cshtml", openedPositions);
        }
    }
}