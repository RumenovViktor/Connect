namespace ApplicationServices
{
    using Data.Unit_Of_Work;
    using DTOs.Models;
    using Models;
    using System.Linq;

    public class CompanyProfileApplicationService : ICompanyProfileApplicationService
    {
        private readonly IDALServiceData dalServiceData;

        public CompanyProfileApplicationService(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public AddPosition Execute(AddPosition command)
        {
            var newPosition = new Position()
            {
                PositionName = command.PositionName,
                Description = command.PositionDescription,
                CompanyId = command.CompanyId
            };

            dalServiceData.Positions.AddEntity(newPosition);
            dalServiceData.Companies.FindEntity(x => x.Id == command.CompanyId).Positions.Add(newPosition);

            dalServiceData.Positions.SaveChanges();
            dalServiceData.Companies.SaveChanges();

            command.PositionId = dalServiceData.Positions.All().Select(x => x.Id).AsEnumerable().Last();
            return command;
        }
    }
}
