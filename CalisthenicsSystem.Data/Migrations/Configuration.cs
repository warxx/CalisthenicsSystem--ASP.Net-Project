using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CalisthenicsSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CalisthenicsSystem.Data.CalisthenicsSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CalisthenicsSystemContext, Configuration>());
        }

        protected override void Seed(CalisthenicsSystemContext context)
        {
            //if (!context.Roles.Any(role => role.Name == "User"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole("User");
            //    manager.Create(role);
            //}

            //if (!context.Roles.Any(role => role.Name == "Admin"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole("Admin");
            //    manager.Create(role);
            //}

            //if (!context.Roles.Any(role => role.Name == "Moderator"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole("Moderator");
            //    manager.Create(role);
            //}

            //if (!context.Roles.Any(role => role.Name == "BlogAuthor"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole("BlogAuthor");
            //    manager.Create(role);
            //}
        }
    }
}
