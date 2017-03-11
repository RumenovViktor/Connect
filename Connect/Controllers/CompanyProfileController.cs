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

        public CompanyProfileController(ICompanyProfileApplicationService companyProfileCommandHandler)
        {
            this.companyProfileCommandHandler = companyProfileCommandHandler;
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
    }
}