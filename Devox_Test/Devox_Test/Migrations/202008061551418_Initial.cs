namespace Devox_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeTrackers",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        ProjectId = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        ActivityTypeId = c.Int(nullable: false),
                        HoursNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.Date, t.ProjectId, t.RoleID, t.ActivityTypeId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TimeTrackers");
            DropTable("dbo.Roles");
            DropTable("dbo.Projects");
            DropTable("dbo.Employees");
            DropTable("dbo.ActivityTypes");
        }
    }
}
