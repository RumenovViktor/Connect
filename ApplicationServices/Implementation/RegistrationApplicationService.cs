//namespace ApplicationServices
//{
//    using System;
//    using Connect.Helpers;
//    using Models;
//    using Data.Unit_Of_Work;
//    using System.Collections.Generic;
//    using DTOs.Models;

//    public class RegistrationApplicationService : IRegistrationApplicationService
//    {
//        private readonly IDALServiceData dalServiceData;

//        public RegistrationApplicationService(IDALServiceData data)
//        {
//            dalServiceData = data;
//        }

//        public UserRegistration Execute(UserRegistration command)
//        {
//            var registeredUser = ExecuteSaveCommand(command);
//            return (UserRegistration)registeredUser;
//        }

//        private ICommand ExecuteSaveCommand(UserRegistration command)
//        {
//            var existingUser = dalServiceData.Users.FindEntity(x => x.Email == command.Email);

//            if (existingUser != null)
//            {
//                return new UserRegistration()
//                {
//                    UserExists = true
//                };
//            }

//            var newUser = new User()
//            {
//                Email = command.Email,
//                FirstName = command.FirstName,
//                LastName = command.LastName,
//                Skills = default(IList<Skill>),
//                IsDeleted = default(bool),
//                DateOfCreation = DateTime.UtcNow,
//                CountryId = command.CountryId,
//                UserName = command.Email
//            };

//            dalServiceData.Users.AddEntity(newUser);
//            dalServiceData.Users.SaveChanges();

//            existingUser = dalServiceData.Users.FindEntity(x => x.Email == command.Email);
//            command.UserId = existingUser.Id;

//            return command;
//        }
//    }
//}
