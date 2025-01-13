using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class AddWorkTypeToDeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkType",
                schema: "dbo",
                table: "Developers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkType",
                schema: "dbo",
                table: "Developers");
        }
    }
}
