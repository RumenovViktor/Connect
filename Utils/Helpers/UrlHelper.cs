﻿using System.Configuration;

namespace Connect.Helpers
{
    public static class UrlHelper
    {
        public static string RegistrationApiUrl { get { return ConfigurationManager.AppSettings["registerApiUrl"]; } }

        public static string LoginApiUrl { get { return ConfigurationManager.AppSettings["loginApiUrl"];} }

        public static string UserBasicInfoUrl { get { return ConfigurationManager.AppSettings["userBasicInfoUrl"]; } }

        public static string SupportedSectorsUrl { get { return ConfigurationManager.AppSettings["supportedSectorsUrl"]; } }

        public static string SupportedCompaniesUrl { get { return ConfigurationManager.AppSettings["supportedCompaniesUrl"]; } }
    }
}
