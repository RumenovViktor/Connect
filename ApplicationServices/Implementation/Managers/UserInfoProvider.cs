namespace ApplicationServices
{
    using Models;
    using Connect.Helpers;
    using System.Collections.Generic;
    using Models.Profile;
    using Models.Dashboard;
    using System;
    using Data.Unit_Of_Work;
    using System.Linq;
    using Utils;
    using Models.Global;
    using DTOs.Models;

    public class UserInfoProvider : IUserInfoProvider
    {
        private readonly IDALServiceData dalServiceData;

        public UserInfoProvider(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public BasicUserInfo GetBasicUserInfo(string email)
        {
            BasicUserInfo basicUserInfo = null;
            var registeredUser = dalServiceData.Users.FindEntity(x => x.Email == email);
            var profileImage = registeredUser.Files.Select(x => x.FileInputStream).FirstOrDefault();
            var country = dalServiceData.Countries.FindEntity(x => x.CountryId == registeredUser.CountryId);

            if (registeredUser != null)
                basicUserInfo = new BasicUserInfo(registeredUser.UserId, profileImage, registeredUser.Email, registeredUser.FirstName, registeredUser.LastName,
                                                    Gender.Male, registeredUser.DateOfCreation, new CountryReadModel(country.CountryId, country.NiceName));

            return basicUserInfo;
        }

        //TODO: Make a class or check if there is a class that deals with this kind of functionality.
        public IList<SupportedSector> GetSupportedSectors()
        {
            var allSupportedSectorsFromDb = dalServiceData.Sectors.All().ToList();
            var allSupportedSectors = allSupportedSectorsFromDb
                    .Select(x => new SupportedSector(x.Id, x.Name)).ToList();

            return allSupportedSectors;
        }

        //TODO: Make a class or check if there is a class that deals with this kind of functionality.
        public IList<SupportedCompany> GetSupportedCompanies(int sectorId)
        {
            var companiesForSector = dalServiceData.Sectors
                .FindEntity(x => x.Id == sectorId)
                .Companies
                .Select(x => new SupportedCompany()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return companiesForSector;
        }

        //TODO: Write operations - should be in application service
        public ExperienceViewModel AddExperience(ExperienceViewModel experience)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Email == experience.UserEmail);

            user.Experience.Add(new Experience(experience));
            dalServiceData.Users.UpdateEntity(user);
            dalServiceData.Users.SaveChanges();

            return experience;
        }

        public Profile GetUserProfile(string email)
        {
            var userExperience = dalServiceData.Users
                                .FindEntity(x => x.Email == email)
                                .Experience.OrderByDescending(x => x.ExperienceId)
                                .Select(x => new ExperienceViewModel()
                                {
                                    Description = x.PositionDiscription,
                                    Position = x.PositionName,
                                    EndDate = x.ToDate,
                                    StartDate = x.FromDate
                                }).ToList();

            return new Profile() { UserExperience = userExperience };
        }

        public UserDashboardProfile GetUserDashboardProfile(long userId)
        {
            var user = dalServiceData.Users.FindEntity(x => x.UserId == userId);
            var userCurrentPosition = user.Experience.Where(x => !x.ToDate.HasValue).FirstOrDefault();

            return new UserDashboardProfile(user.FirstName + " " + user.LastName, userCurrentPosition != null ? userCurrentPosition.PositionName : string.Empty);
        }
    }
}