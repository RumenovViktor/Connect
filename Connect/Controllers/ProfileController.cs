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

        public ProfileController(IUserInfoProvider userInfoProvider, ISkillsApplicationService skillsApplicationService)
        {
            this.userInfoProvider = userInfoProvider;
            this.skillsApplicationService = skillsApplicationService;
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

        [HttpGet]
        public ActionResult GetSkills(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Json(new { }, JsonRequestBehavior.AllowGet);

            var matchedSkills = skillsApplicationService.GetMatchedSkills(name);

            return Json(matchedSkills, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSkill(string name)
        {
            if (ModelState.IsValid)
            {
                var userEmail = (string)CurrentUser.GetParameterByKey("email");
                skillsApplicationService.AddSkill(new SkillDtoWriteModel(name, userEmail));
            }

            return PartialView();
        }
    }
}