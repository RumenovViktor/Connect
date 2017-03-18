namespace ApplicationServices
{
    using System.Collections.Generic;

    using Models;
    using Models.Profile;
    using Models.Dashboard;

    public interface IUserInfoProvider
    {
        BasicUserInfo GetBasicUserInfo(string email);

        IList<SupportedSector> GetSupportedSectors();

        IList<SupportedCompany> GetSupportedCompanies(int sectorId);

        ExperienceViewModel AddExperience(ExperienceViewModel experience);

        UserDashboardProfile GetUserDashboardProfile(long userId);

        Profile GetUserProfile(string email);
    }
}
