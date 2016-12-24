namespace ApplicationServices
{
    using System.Collections.Generic;

    using Models;
    
    public interface IUserInfoProvider
    {
        BasicUserInfo GetBasicUserInfo(string email);

        IList<SupportedSector> GetSupportedSectors();

        IList<SupportedCompany> GetSupportedCompanies(int sectorId);

        void AddExperience(ExperienceViewModel experience);

        Profile GetUserProfile(string email);
    }
}
