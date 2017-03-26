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
    using Data;
    using Microsoft.AspNet.Identity;

    public class UserInfoProvider : IUserInfoProvider
    {

        private readonly IDALServiceData dalServiceData;

        public UserInfoProvider(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public BasicUserInfo GetBasicUserInfo(int userId)
        {
            BasicUserInfo basicUserInfo = null;
            var registeredUser = dalServiceData.Users.FindEntity(x => x.Id == userId);
            var profileImage = registeredUser.Files.Select(x => x.FileInputStream).FirstOrDefault();
            var country = dalServiceData.Countries.FindEntity(x => x.CountryId == registeredUser.CountryId);

            if (registeredUser != null)
                basicUserInfo = new BasicUserInfo(registeredUser.Id, profileImage, registeredUser.Email, registeredUser.FirstName, registeredUser.LastName,
                                                    Gender.Male, registeredUser.DateOfCreation, new CountryReadModel(country.CountryId, country.NiceName));

            return basicUserInfo;
        }

        public IList<BasicUserInfo> MatchUserEmail(string email)
        {
            var matchedUsers = dalServiceData.Users.All().Where(x => x.Email.StartsWith(email))
                .Select(x => new BasicUserInfo(x.Id, null, x.Email, null, null, Gender.Male, DateTime.Now, null)).ToList();

            return matchedUsers;
        }

        //TODO: Make a class or check if there is a class that deals with this kind of functionality.
        public IList<SupportedSector> GetSupportedSectors()
        {
            var allSupportedSectorsFromDb = dalServiceData.Sectors.All().ToList();
            var allSupportedSectors = allSupportedSectorsFromDb
                    .Select(x => new SupportedSector(x.Id, x.Name)).ToList();

            return allSupportedSectors;
        }

        ////TODO: Make a class or check if there is a class that deals with this kind of functionality.
        //public IList<SupportedCompany> GetSupportedCompanies(int sectorId)
        //{
        //    var companiesForSector = dalServiceData.Sectors
        //        .FindEntity(x => x.Id == sectorId)
        //        .Companies
        //        .Select(x => new SupportedCompany()
        //        {
        //            Id = x.Id,
        //            Name = x.Name
        //        }).ToList();

        //    return companiesForSector;
        //}

        //TODO: Write operations - should be in application service
        public ExperienceViewModel AddExperience(ExperienceViewModel experience, UserManager userManager)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Id == experience.UserId);
            var daysOfExperience = experience.EndDate.HasValue ? experience.EndDate.Value.Subtract(experience.StartDate.Value).TotalDays : DateProvider.UtcNow.Subtract(experience.StartDate.Value).TotalDays;
            var totalDaysOfExperience = user.DaysOfExperience.HasValue ? user.DaysOfExperience.Value + daysOfExperience : daysOfExperience;
            user.DaysOfExperience = totalDaysOfExperience;

            user.Experience.Add(new Experience(experience));
            dalServiceData.Users.UpdateEntity(user);
            dalServiceData.Users.SaveChanges();

            return experience;
        }

        public Profile GetUserProfile(int userId)
        {
            var user = dalServiceData.Users .FindEntity(x => x.Id == userId);
            var yearsOfExperience = DateProvider.ConvertToYears(user.DaysOfExperience);

            var userExperience = user.Experience.OrderByDescending(x => x.ExperienceId)
                                .Select(x => new ExperienceViewModel()
                                {
                                    Description = x.PositionDiscription,
                                    Position = x.PositionName,
                                    EndDate = x.ToDate,
                                    StartDate = x.FromDate
                                }).ToList();

            var userSkills = user.Skills.Select(x => x.Name).ToList();
            var profileImage = user.Files.Select(x => x.FileInputStream).FirstOrDefault();

            return new Profile() { UserExperience = userExperience, Skills = userSkills, ProfileImage = profileImage, YearsOfExperience = yearsOfExperience, UserName = user.UserName };
        }

        public UserDashboardProfile GetUserDashboardProfile(int userId)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Id == userId);
            var profileImage = user.Files.Select(x => x.FileInputStream).FirstOrDefault();
            var userCurrentPosition = user.Experience.Where(x => !x.ToDate.HasValue).FirstOrDefault();

            return new UserDashboardProfile(user.FirstName + " " + user.LastName, userCurrentPosition != null ? userCurrentPosition.PositionName : string.Empty, profileImage, user.UserName);
        }

        public IList<CreatedPosition> GetCreatedPositions(int userId)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Id == userId);
            return user.Positions.Select(x => new CreatedPosition(x.Id, x.PositionName)).ToList();
        }
    }
}