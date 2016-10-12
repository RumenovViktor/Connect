namespace Connect.Controllers
{
    using System.Web.Mvc;

    using ApplicationServices;
    using Models;

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
        public ActionResult ProfileBasicInfo(UserBusinessInfo userBusinessInfo)
        {
            BasicUserInfo currentUser = null;

            if (userBusinessInfo.IsAfterRegistration)
            {
                currentUser = new BasicUserInfo(null, userBusinessInfo.Email, userBusinessInfo.FirstName, userBusinessInfo.LastName, userBusinessInfo.Gender);
            }
            else
            {
                currentUser = userInfoProvider.GetBasicUserInfo(userBusinessInfo.Email);
            }

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