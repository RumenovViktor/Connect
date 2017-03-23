namespace Data.Migrations
{
    using System.Data.Entity.Migrations;

    using DataContext;
    using DTOs.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using Data;
    using Repository.Implementation;

    internal sealed class Configuration : DbMigrationsConfiguration<DALServiceDataContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DALServiceDataContext context)
        {
            var userStore = new UserStore(context);
            var manager = new UserManager(userStore);
            var roleStore = new RoleStore(context);
            var roleManager = new RoleManager(roleStore);

            var user = new User() { UserName = "Shasdadaro", FirstName = "Shssari", LastName = "Shassri", DateOfCreation = DateTime.Now, Email = "ahsdi@hiusdf.fd" };
            IdentityResult result = manager.Create(user, "asdasdasdasasd");
            var user2 = manager.FindById(1);
            roleManager.Create(new Role("Recruiter"));

            manager.AddToRole(user2.Id, "Recruiter");

            if (result.Succeeded)
            {

            }
            else
            {

            }
        }
    }
}
