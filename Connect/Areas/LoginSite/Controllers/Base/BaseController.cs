namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;

    public class BaseController : Controller
    {
        #region Protected Methods

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