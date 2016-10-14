using System.Web;
using System.Web.Mvc;

using ApplicationServices;
using Connect.Helpers;

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
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult ProfileBasicInfo()
        {
            var email = CurrentUser.GetParameterByKey("email");
            var currentUser = userInfoProvider.GetBasicUserInfo((string)email);

            return PartialView(currentUser);
        }
    }
}