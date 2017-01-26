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

        public ProfileController(IUserInfoProvider userInfoProvider)
        {
            this.userInfoProvider = userInfoProvider;
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
        public ActionResult AddExperience()
        {
            return PartialView();
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
        [OutputCache(Duration = 60 * 60 * 60)]
        public ActionResult AddSkill()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSkill(string name)
        {
            return PartialView();
        }
    }
}