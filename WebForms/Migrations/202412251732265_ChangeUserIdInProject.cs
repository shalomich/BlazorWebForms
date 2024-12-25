namespace WebForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIdInProject : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Projects", new[] { "User_Id" });
            DropColumn("dbo.Projects", "UserId");
            RenameColumn(table: "dbo.Projects", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Projects", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Projects", new[] { "UserId" });
            AlterColumn("dbo.Projects", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Projects", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Projects", "UserId", c => c.Int());
            CreateIndex("dbo.Projects", "User_Id");
        }
    }
}
