namespace WebForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStartDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "StartDate");
        }
    }
}
