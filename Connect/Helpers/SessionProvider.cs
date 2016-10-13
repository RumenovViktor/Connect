using System;
using System.Web;
using System.Web.SessionState;

namespace Connect.Helpers
{
    public class CurrentUser
    {
        public static object GetParameterByKey(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return HttpContext.Current.Session[key];
            }

            throw new ArgumentException("Session does not contain such key: " + key);
        }

        public static void AddParameter(string key, object value)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                HttpContext.Current.Session.Add(key, value);
            }
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
