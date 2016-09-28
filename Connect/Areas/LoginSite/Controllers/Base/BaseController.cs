namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        #region Protected Methods

        [NonAction]
        protected void PreserveModelStateErrors()
        {

        }

        #endregion
    }
}