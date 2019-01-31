namespace TidrAppProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PersonalNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        HiredDate = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Postcode = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        ProfilePic = c.String(),
                        Notes = c.String(nullable: false),
                        HourlySalary = c.Double(nullable: false),
                        MonthlySalary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkShifts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TotalTime = c.Double(nullable: false),
                        OB1 = c.Double(nullable: false),
                        OB2 = c.Double(nullable: false),
                        FirstSickDay = c.Boolean(nullable: false),
                        SickDayTime = c.Double(nullable: false),
                        VAB = c.Double(nullable: false),
                        Employee_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employee_ID)
                .Index(t => t.Employee_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkShifts", "Employee_ID", "dbo.Employees");
            DropIndex("dbo.WorkShifts", new[] { "Employee_ID" });
            DropTable("dbo.WorkShifts");
            DropTable("dbo.Employees");
        }
    }
}
