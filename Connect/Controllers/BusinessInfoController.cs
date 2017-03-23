namespace Connect.Controllers
{
    using System.Web.Mvc;

    using ApplicationServices;
    using Models;
    using Helpers;
    using Data;
    using System.Web;
    using Data.Repository.Implementation;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class BusinessInfoController : BaseController
    {
        public UserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<UserManager>();
            }
        }

        public SignInManager SignInManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<SignInManager>();
            }
        }

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
        public ActionResult UserBasicInfo()
        {
            var userId = SignInManager.AuthenticationManager.User.Identity.GetUserId();
            var currentUser = userInfoProvider.GetBasicUserInfo(int.Parse(userId));

            return PartialView(currentUser);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult SupportedSectors()
        {
            var allSupportedSectors = userInfoProvider.GetSupportedSectors();
            return PartialView(allSupportedSectors);
        }

        //[HttpGet]
        //public ActionResult SupportedCompanies(int sectorId)
        //{
        //    var supportedCompaniesForSector = userInfoProvider.GetSupportedCompanies(sectorId);
        //    return PartialView(supportedCompaniesForSector);
        //}
    }
}