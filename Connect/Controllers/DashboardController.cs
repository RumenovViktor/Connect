using ApplicationServices;
using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Models;
using System.Web;
using System.Web.Mvc;

namespace Connect.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        public UserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<UserManager>();
            }
        }

        private readonly IDashboardManager dashboardInfoProvider;
        private readonly ICommonInfoManager commonInfoProvider;
        private readonly IUserInfoProvider userInfoProvider;

        public DashboardController(ICommonInfoManager commonInfoProvider, IUserInfoProvider userInfoProvider, IDashboardManager dashboardInfoProvider)
        {
            this.commonInfoProvider = commonInfoProvider;
            this.userInfoProvider = userInfoProvider;
            this.dashboardInfoProvider = dashboardInfoProvider;
        }

        [HttpGet]
        public ActionResult UserDashboard()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var isRecruiter = UserManager.IsInRole(userId, "Recruiter");
            var userDashboardProfile = userInfoProvider.GetUserDashboardProfile(userId);

            if (isRecruiter)
            {
                Session["userName"] = User.Identity.GetUserName();
                return View("RecruiterDashboard/RecruiterDashboard", userDashboardProfile);
            }

            return View(userDashboardProfile);
        }

        [HttpGet]
        public ActionResult TheWall()
        {
            var activityArea = commonInfoProvider.GetActivityArea();

            return PartialView(new TheWall(activityArea));
        }

        [HttpGet]
        public ActionResult UserSuitiblePositions(int? sectorId, int? countryId)
        {
            var userId = User.Identity.GetUserId();
            var suitiblePositions = dashboardInfoProvider.GetSuitiblePositions(sectorId, countryId, int.Parse(userId));
            return PartialView(suitiblePositions);
        }

        [HttpGet]
        public ActionResult CandidateSuggestions(int positionId)
        {
            var suitiblePositions = dashboardInfoProvider.GetCandidateSuggestions(null, null, positionId);
            return PartialView("RecruiterDashboard/CandidateSuggestions", suitiblePositions);
        }
    }
}