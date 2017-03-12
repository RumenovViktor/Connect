using ApplicationServices;
using Connect.Helpers;
using Models;
using System.Web.Mvc;

namespace Connect.Controllers
{
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
            var userId = (long)CurrentUser.GetParameterByKey("userId");
            var userDashboardProfile = userInfoProvider.GetUserDashboardProfile(userId);
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
            var userId = (string)CurrentUser.GetParameterByKey("email");
            var suitiblePositions = dashboardInfoProvider.GetSuitiblePositions(sectorId, countryId, userId);
            return PartialView(suitiblePositions);
        }
    }
}