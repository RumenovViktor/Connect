namespace ApplicationServices
{
    using Data.Unit_Of_Work;
    using DTOs.Models;
    using Models;
    using System.Linq;

    public class ProfileApplicationService : IProfileApplicationService
    {
        private readonly IDALServiceData dalServiceData;

        public ProfileApplicationService(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public AddPosition Execute(AddPosition command)
        {
            var newPosition = new Position()
            {
                PositionName = command.PositionName,
                Description = command.PositionDescription,
                Introduction = command.Introduction,
                WhatWeProvide = command.WhatWeProvide,
                NeededYearsOfExperience = command.NeededYearsOfExperience
            };

            dalServiceData.Positions.AddEntity(newPosition);
            dalServiceData.Users.FindEntity(x => x.Id == command.UserId).Positions.Add(newPosition);

            dalServiceData.Positions.SaveChanges();
            dalServiceData.Users.SaveChanges();

            command.PositionId = dalServiceData.Positions.All().Select(x => x.Id).AsEnumerable().Last();
            return command;
        }
    }
}
