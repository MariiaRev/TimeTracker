using Devox_Test.Models;
namespace Devox_Test.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Devox_Test.Models.Devox_TestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Devox_Test.Models.Devox_TestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Employees.AddOrUpdate(x => x.Id,
                new Employee() { Id = 1, Name = "Alex Danvers", Sex = false, Birthday = new DateTime(1990, 10, 26)}
                );

            context.Projects.AddOrUpdate(x => x.Id,
                new Project() { Id = 1, Name = "Project_1"},
                new Project() { Id = 2, Name = "Project_2" },
                new Project() { Id = 3, Name = "Project_3" }
                );

            context.ActivityTypes.AddOrUpdate(x => x.Id,
                new ActivityType() { Id = 1, Name = "Regular work" },
                new ActivityType() { Id = 2, Name = "Overtime" }
                );

            context.Roles.AddOrUpdate(x => x.Id,
                new Role() { Id = 1, Name = "Team lead"},
                new Role() { Id = 2, Name = "Software engineer" },
                new Role() { Id = 3, Name = "Business analyst" },
                new Role() { Id = 4, Name = "Software architect" }
                );

            context.TimeTrackers.AddOrUpdate( 
                new TimeTracker()
                {
                    EmployeeId = 1,
                    Date = new DateTime(2020, 2, 21),
                    ProjectId = 3,
                    RoleID = 2,
                    ActivityTypeId = 1,
                    HoursNumber = 8
                },
                new TimeTracker()
                {
                    EmployeeId = 1,
                    Date = new DateTime(2020, 2, 22),
                    ProjectId = 2,
                    RoleID = 4,
                    ActivityTypeId = 2,
                    HoursNumber = 2
                },
                new TimeTracker()
                {
                    EmployeeId = 1,
                    Date = new DateTime(2020, 2, 22),
                    ProjectId = 1,
                    RoleID = 1,
                    ActivityTypeId = 1,
                    HoursNumber = 6
                }
                );
        }
    }
}
