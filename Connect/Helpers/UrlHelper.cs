using System.Configuration;

namespace Connect.Helpers
{
    public static class UrlHelper
    {
        public static string RegistrationApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["registerApiUrl"];
            }
        }

        public static string LoginApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["loginApiUrl"];
            }
        }
    }
}
