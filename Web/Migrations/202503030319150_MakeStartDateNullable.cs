namespace WebForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeStartDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "StartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
