namespace Connect.Controllers
{
    using System.Web.Mvc;

    using ApplicationServices;
    using Models;
    using Helpers;

    //[Authorize]
    public class BusinessInfoController : BaseController
    {
        private readonly IUserInfoProvider userInfoProvider;

        public BusinessInfoController(IUserInfoProvider userInfoProvider)
        {
            this.userInfoProvider = userInfoProvider;
        }

        [HttpGet]
        public ActionResult BusinessInfo(UserBusinessInfo userBusinessInfo)
        {
            return View(userBusinessInfo);
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
        [ChildActionOnly]
        public ActionResult SupportedSectors()
        {
            var allSupportedSectors = userInfoProvider.GetSupportedSectors();
            return PartialView(allSupportedSectors);
        }

        [HttpGet]
        public ActionResult SupportedCompanies(int sectorId)
        {
            var supportedCompaniesForSector = userInfoProvider.GetSupportedCompanies(sectorId);
            return PartialView(supportedCompaniesForSector);
        }
    }
}