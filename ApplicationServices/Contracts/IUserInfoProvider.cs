namespace ApplicationServices
{
    using System.Collections.Generic;

    using Models;
    using Models.Profile;
    using Models.Dashboard;
    using Data;

    public interface IUserInfoProvider
    {
        BasicUserInfo GetBasicUserInfo(int userId);

        IList<BasicUserInfo> MatchUserEmail(string email);

        IList<SupportedSector> GetSupportedSectors();

        //IList<SupportedCompany> GetSupportedCompanies(int sectorId);

        ExperienceViewModel AddExperience(ExperienceViewModel experience, UserManager userManager);

        UserDashboardProfile GetUserDashboardProfile(int userId);

        Profile GetUserProfile(int userId);

        IList<CreatedPosition> GetCreatedPositions(int userId);
    }
}
