using System.Configuration;

namespace Connect.Helpers
{
    public static class UrlHelper
    {
        public static string RegistrationApiUrl
        {
            get { return ConfigurationManager.AppSettings["registerApiUrl"]; }
        }

        public static string CompanyRegistrationUrl
        {
            get { return ConfigurationManager.AppSettings["comapnyRegisterApiUrl"]; }
        }

        public static string UserLoginApiUrl
        {
            get { return ConfigurationManager.AppSettings["userLoginApiUrl"]; }
        }

        public static string CompanyLoginUrl
        {
            get { return ConfigurationManager.AppSettings["companyLoginUrl"]; }
        }

        public static string UserBasicInfoUrl
        {
            get { return ConfigurationManager.AppSettings["userBasicInfoUrl"]; }
        }

        public static string CompanyInfoUrl
        {
            get { return ConfigurationManager.AppSettings["companyInfoUrl"]; }
        }

        public static string SupportedSectorsUrl
        {
            get { return ConfigurationManager.AppSettings["supportedSectorsUrl"]; }
        }

        public static string SupportedCompaniesUrl
        {
            get { return ConfigurationManager.AppSettings["supportedCompaniesUrl"]; }
        }

        public static string UploadFileUrl
        {
            get { return ConfigurationManager.AppSettings["uploadFileUrl"]; }
        }

        public static string NewExperienceUrl
        {
            get { return ConfigurationManager.AppSettings["newExperienceUrl"]; }
        }

        public static string GetUserProfile
        {
            get { return ConfigurationManager.AppSettings["getUserProfile"]; }
        }

        public static string GetSkillsUrl
        {
            get { return ConfigurationManager.AppSettings["getSkillsUrl"]; }
        }

        public static string CreateSkillUrl
        {
            get { return ConfigurationManager.AppSettings["createSkillUrl"]; }
        }

        public static string AddPositionUrl
        {
            get { return ConfigurationManager.AppSettings["createPositionUrl"]; }
        }

        public static string AddPositionSkillUrl
        {
            get { return ConfigurationManager.AppSettings["addPositionSkillUrl"]; }
        }

        public static string ActivityAreaUrl
        {
            get { return ConfigurationManager.AppSettings["getActivityAreaUrl"]; }

        }

        public static string UserSuitiblePositions
        {
            get { return ConfigurationManager.AppSettings["userSuitiblePositions"]; }
        }
    }
}
