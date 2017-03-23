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
        private readonly ICompanyInfoProvider companyInfoProvider;
        private readonly ICommonInfoManager commonInfoProvider;

        public ProfileController(IUserInfoProvider userInfoProvider, ISkillsApplicationService skillsApplicationService, ICompanyInfoProvider companyInfoProvider, ICommonInfoManager commonInfoProvider)
        {
            this.userInfoProvider = userInfoProvider;
            this.skillsApplicationService = skillsApplicationService;
            this.companyInfoProvider = companyInfoProvider;
            this.commonInfoProvider = commonInfoProvider;
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

        [HttpGet]
        public ActionResult CompanyProfile()
        {
            var companyId = (long)CurrentUser.GetParameterByKey("companyId");
            var companyProfile = companyInfoProvider.GetCompanyProfile(companyId);

            return View(companyProfile);
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
    }
}