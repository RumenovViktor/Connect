using System;
using Models;
using Connect.Helpers;
using Data.Unit_Of_Work;
using DB = DTOs.Models;

namespace ApplicationServices
{
    public class FileManagementApplicationService : IFileManagementApplicationService
    {
        private readonly IDALServiceData dalServiceData;

        public FileManagementApplicationService(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public File Execute(File command)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Email == command.UserId);

            var newFile = new DB.File()
            {
                Name = command.Name,
                UserId = user.UserId,
                FileInputStream = command.FileInputStream
            };

            user.Files.Add(newFile);
            dalServiceData.Users.UpdateEntity(user);
            dalServiceData.Users.SaveChanges();

            return command;
        }
    }
}
