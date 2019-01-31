namespace TidrAppProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_employees_in_db : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkShifts", "Employee_ID", "dbo.Employees");
            DropIndex("dbo.WorkShifts", new[] { "Employee_ID" });
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.WorkShifts", "Employee_ID", c => c.Int());
            AddPrimaryKey("dbo.Employees", "ID");
            CreateIndex("dbo.WorkShifts", "Employee_ID");
            AddForeignKey("dbo.WorkShifts", "Employee_ID", "dbo.Employees", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkShifts", "Employee_ID", "dbo.Employees");
            DropIndex("dbo.WorkShifts", new[] { "Employee_ID" });
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.WorkShifts", "Employee_ID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Employees", "ID");
            CreateIndex("dbo.WorkShifts", "Employee_ID");
            AddForeignKey("dbo.WorkShifts", "Employee_ID", "dbo.Employees", "ID");
        }
    }
}
