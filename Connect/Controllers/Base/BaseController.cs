namespace Connect.Controllers
{
    using Antlr.Runtime.Misc;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected ActionResult ExecuteAction<T>(ModelStateDictionary modelState, Func<T> action)
        {
            if (modelState.IsValid)
            {
                var result = action();
                return Json(result, JsonRequestBehavior.DenyGet);
            }

            return Json(null, JsonRequestBehavior.DenyGet); ;
        }
    }
}