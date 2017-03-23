using ApplicationServices;
using Microsoft.AspNet.Identity;
using Models;
using System.Web.Mvc;

namespace Connect.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
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
            var userId = User.Identity.GetUserId();
            var userDashboardProfile = userInfoProvider.GetUserDashboardProfile(int.Parse(userId));
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
    }
}