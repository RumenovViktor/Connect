using ApplicationServices;
using Connect.Helpers;
using Models;
using System.Web.Mvc;

namespace Connect.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly ICommonInfoManager commonInfoProvider;
        private readonly IUserInfoProvider userInfoProvider;

        public DashboardController(ICommonInfoManager commonInfoProvider, IUserInfoProvider userInfoProvider)
        {
            this.commonInfoProvider = commonInfoProvider;
            this.userInfoProvider = userInfoProvider;
        }

        [HttpGet]
        public ActionResult UserDashboard()
        {
            return View();
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
            var suitiblePositions = userInfoProvider.GetSuitiblePositions(sectorId, countryId, userId);
            return PartialView(suitiblePositions);
        }
    }
}