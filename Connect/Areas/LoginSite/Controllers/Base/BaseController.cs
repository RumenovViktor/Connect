namespace Connect.Areas.LoginSite.Controllers
{
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        #region Protected Methods

        protected void ValidateRequest(Controller controller, ViewContext operationOnValid, ViewContext opertationOnNotValid)
        {
            if (controller.ModelState.IsValid)
            {
                
            }
            else
            {

            }
        }

        [NonAction]
        protected void PreserveModelStateErrors()
        {

        }

        #endregion
    }
}