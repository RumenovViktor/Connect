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

            if (roleManager.FindByName("Recruiter") == null)
            {
                roleManager.Create(new Role("Recruiter"));
            }

            if (roleManager.FindByName("Candidate") == null)
            {
                roleManager.Create(new Role("Candidate"));
            }
        }
    }
}
