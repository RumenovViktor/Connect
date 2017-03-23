namespace Connect.Areas.LoginSite.Controllers
{
    using Data;
    using Data.DataContext;
    using Data.Repository.Implementation;
    using Microsoft.AspNet.Identity.Owin;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    public class BaseController : Controller
    {
        #region Protected Methods

        protected readonly UserManager userManager;
        protected readonly RoleManager roleManager;

        public BaseController() { }

        public BaseController(IDALServiceDataContext dalserviceDataContext)
        {
            this.userManager = Request.GetOwinContext().GetUserManager<UserManager>();

            var roleStore = new RoleStore((DALServiceDataContext)dalserviceDataContext);
            this.roleManager = new RoleManager(roleStore);
        }

        protected void RemoveAuthenticationCoockie()
        {
            FormsAuthentication.SignOut();
        }

        protected void SetAuthenticationCoockie(string email)
        {
            FormsAuthentication.SetAuthCookie(email, true);
        }

        [NonAction]
        protected void PreserveModelStateErrors()
        {

        }

        #endregion
    }
}