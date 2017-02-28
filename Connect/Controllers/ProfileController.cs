using System.Web;
using System.Web.Mvc;

using ApplicationServices;
using Connect.Helpers;
using Models;

namespace Connect.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IUserInfoProvider userInfoProvider;
        private readonly ISkillsApplicationService skillsApplicationService;
        private readonly ICompanyInfoProvider companyInfoProvider;

        public ProfileController(IUserInfoProvider userInfoProvider, ISkillsApplicationService skillsApplicationService, ICompanyInfoProvider companyInfoProvider)
        {
            this.userInfoProvider = userInfoProvider;
            this.skillsApplicationService = skillsApplicationService;
            this.companyInfoProvider = companyInfoProvider;
        }

        [HttpGet]
        public new ActionResult Profile()
        {
            var email = CurrentUser.GetParameterByKey("email");
            var currentUser = userInfoProvider.GetUserProfile((string)email);

            return View(currentUser);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult ProfileBasicInfo()
        {
            var email = CurrentUser.GetParameterByKey("email");
            var currentUser = userInfoProvider.GetBasicUserInfo((string)email);

            return PartialView(currentUser);
        }

        [HttpGet]
        public ActionResult CompanyProfile()
        {
            var companyName = (string)CurrentUser.GetParameterByKey("companyName");
            var companyProfile = companyInfoProvider.GetCompanyProfile(companyName);

            return View(companyProfile);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddExperience(ExperienceViewModel experience)
        {
            if (ModelState.IsValid)
            {
                experience.UserEmail = (string)CurrentUser.GetParameterByKey("email");

                userInfoProvider.AddExperience(experience);

                return PartialView("Experience", experience);
            }

            return PartialView(experience);
        }
    }
}