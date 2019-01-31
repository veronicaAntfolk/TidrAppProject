namespace TidrAppProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_field_for_userID_in_employees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "UserID");
        }
    }
}
