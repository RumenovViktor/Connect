namespace ApplicationServices
{
    using System.Collections.Generic;

    using Models;
    using Models.Profile;
    using Models.Dashboard;

    public interface IUserInfoProvider
    {
        BasicUserInfo GetBasicUserInfo(int userId);

        IList<BasicUserInfo> MatchUserEmail(string email);

        IList<SupportedSector> GetSupportedSectors();

        //IList<SupportedCompany> GetSupportedCompanies(int sectorId);

        ExperienceViewModel AddExperience(ExperienceViewModel experience);

        UserDashboardProfile GetUserDashboardProfile(int userId);

        Profile GetUserProfile(int userId);
    }
}
