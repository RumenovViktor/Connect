namespace Connect.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using ApplicationServices;
    using Models;
    using System;
    using Helpers;

    public class CompanyProfileController : BaseController
    {
        private readonly ICompanyProfileApplicationService companyProfileCommandHandler;
        private readonly IUserInfoProvider userBasicInfoProvider;

        public CompanyProfileController(ICompanyProfileApplicationService companyProfileCommandHandler, IUserInfoProvider userBasicInfoProvider)
        {
            this.companyProfileCommandHandler = companyProfileCommandHandler;
            this.userBasicInfoProvider = userBasicInfoProvider;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPosition(AddPosition newPosition)
        {
            if (ModelState.IsValid)
            {
                var companyId = (long)CurrentUser.GetParameterByKey("companyId");
                newPosition.CompanyId = companyId;
                var position = companyProfileCommandHandler.Execute(newPosition);

                return PartialView("~/Views/Profile/CreatedPosition.cshtml", new CreatedPosition(position.PositionId, position.PositionName));
            }

            return Json(new { error = "Could not create position" }, JsonRequestBehavior.DenyGet);
        }

        [HttpGet]
        public ActionResult FindUser(string email)
        {
            var matchedUsers = userBasicInfoProvider.MatchUserEmail(email);
            return PartialView(matchedUsers);
        }

        [HttpPost]
        public ActionResult AssocciateUser(string email)
        {

            return null;
        }
    }
}