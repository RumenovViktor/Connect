using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Connect.Controllers
{
    public class DashboardController : BaseController
    {
        [HttpGet]
        public ActionResult UserDashboard()
        {
            return View();
        }
    }
}