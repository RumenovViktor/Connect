using System;
using System.Web;
using System.Web.SessionState;

namespace Connect.Helpers
{
    public class CurrentUser
    {
        public static object GetParameterByKey(string key)
        {
            return HttpContext.Current.Session[key];
        }

        public static void AddParameter(string key, object value)
        {
            HttpContext.Current.Session.Add(key, value);
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
