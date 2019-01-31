namespace TidrAppProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
        }
    }
}
