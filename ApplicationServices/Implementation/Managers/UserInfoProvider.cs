namespace ApplicationServices
{
    using Models;
    using Connect.Helpers;
    using System.Collections.Generic;
    using Models.Profile;
    using Models.Dashboard;
    using System;

    public class UserInfoProvider : IUserInfoProvider
    {
        public BasicUserInfo GetBasicUserInfo(string email)
        {
            var queryParamas = new Dictionary<string, string>();
            queryParamas.Add("email", email);

            var basicUserInfo = WebServiceProvider<BasicUserInfo>.Get(UrlHelper.UserBasicInfoUrl, queryParamas);
            return basicUserInfo;
        }

        //TODO: Make a class or check if there is a class that deals with this kind of functionality.
        public IList<SupportedSector> GetSupportedSectors()
        {
            var allSupportedSectors = WebServiceProvider<IList<SupportedSector>>.Get(UrlHelper.SupportedSectorsUrl);
            return allSupportedSectors;

        }

        //TODO: Make a class or check if there is a class that deals with this kind of functionality.
        public IList<SupportedCompany> GetSupportedCompanies(int sectorId)
        {
            var queryParamas = new Dictionary<string, string>();
            queryParamas.Add("sectorId", sectorId.ToString());

            var allSupportedCompanies = WebServiceProvider<IList<SupportedCompany>>.Get(UrlHelper.SupportedCompaniesUrl, queryParamas);
            return allSupportedCompanies;
        }

        //TODO: Write operations - should be in application service
        public void AddExperience(ExperienceViewModel experience)
        {
            WebServiceProvider<ExperienceViewModel>.Post(experience, UrlHelper.NewExperienceUrl);
        }

        public Profile GetUserProfile(string email)
        {
            var queryParamas = new Dictionary<string, string>();
            queryParamas.Add("email", email);

            var basicUserInfo = WebServiceProvider<Profile>.Get(UrlHelper.GetUserProfile, queryParamas);
            return basicUserInfo;
        }

        public UserDashboardProfile GetUserDashboardProfile(long userId)
        {
            var userDashboardProfile = WebServiceProvider<UserDashboardProfile>.Get(UrlHelper.UserDashboardProfileUrl, new Dictionary<string, string>()
            {
                { "userId", userId.ToString() }
            });

            return userDashboardProfile;
        }
    }
}