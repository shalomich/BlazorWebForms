namespace WebForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkTypeToDeveloper : DbMigration
    {
        public override void Up()
        {
           AddColumn("dbo.Developers", "WorkType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Developers", "WorkType");
        }
    }
}
