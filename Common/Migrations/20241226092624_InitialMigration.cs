using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Common.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "dbo");

            //migrationBuilder.CreateTable(
            //    name: "__MigrationHistory",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        MigrationId = table.Column<string>(maxLength: 150, nullable: false),
            //        ContextKey = table.Column<string>(maxLength: 300, nullable: false),
            //        Model = table.Column<byte[]>(nullable: false),
            //        ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(maxLength: 128, nullable: false),
            //        Name = table.Column<string>(maxLength: 256, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(maxLength: 128, nullable: false),
            //        Email = table.Column<string>(maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false),
            //        UserName = table.Column<string>(maxLength: 256, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        UserId = table.Column<string>(maxLength: 128, nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true),
            //        ApplicationUserId = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_ApplicationUserId",
            //            column: x => x.ApplicationUserId,
            //            principalSchema: "dbo",
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
            //        ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
            //        UserId = table.Column<string>(maxLength: 128, nullable: false),
            //        ApplicationUserId = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_dbo.AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey, x.UserId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_ApplicationUserId",
            //            column: x => x.ApplicationUserId,
            //            principalSchema: "dbo",
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(maxLength: 128, nullable: false),
            //        RoleId = table.Column<string>(maxLength: 128, nullable: false),
            //        ApplicationUserId = table.Column<string>(nullable: true),
            //        AspNetRoleId = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_dbo.AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_ApplicationUserId",
            //            column: x => x.ApplicationUserId,
            //            principalSchema: "dbo",
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_AspNetRoleId",
            //            column: x => x.AspNetRoleId,
            //            principalSchema: "dbo",
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalSchema: "dbo",
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Projects",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Name = table.Column<string>(nullable: true),
            //        UserId = table.Column<string>(maxLength: 128, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Projects", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_dbo.Projects_dbo.AspNetUsers_User_Id",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Developers",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Name = table.Column<string>(nullable: true),
            //        ProjectId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Developers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_dbo.Developers_dbo.Projects_ProjectId",
            //            column: x => x.ProjectId,
            //            principalSchema: "dbo",
            //            principalTable: "Projects",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "AspNetRoles_RoleNameIndex",
            //    schema: "dbo",
            //    table: "AspNetRoles",
            //    column: "Name",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_ApplicationUserId",
            //    schema: "dbo",
            //    table: "AspNetUserClaims",
            //    column: "ApplicationUserId");

            //migrationBuilder.CreateIndex(
            //    name: "AspNetUserClaims_IX_UserId",
            //    schema: "dbo",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_ApplicationUserId",
            //    schema: "dbo",
            //    table: "AspNetUserLogins",
            //    column: "ApplicationUserId");

            //migrationBuilder.CreateIndex(
            //    name: "AspNetUserLogins_IX_UserId",
            //    schema: "dbo",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_ApplicationUserId",
            //    schema: "dbo",
            //    table: "AspNetUserRoles",
            //    column: "ApplicationUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_AspNetRoleId",
            //    schema: "dbo",
            //    table: "AspNetUserRoles",
            //    column: "AspNetRoleId");

            //migrationBuilder.CreateIndex(
            //    name: "AspNetUserRoles_IX_RoleId",
            //    schema: "dbo",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "AspNetUserRoles_IX_UserId",
            //    schema: "dbo",
            //    table: "AspNetUserRoles",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "AspNetUsers_UserNameIndex",
            //    schema: "dbo",
            //    table: "AspNetUsers",
            //    column: "UserName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "Developers_IX_ProjectId",
            //    schema: "dbo",
            //    table: "Developers",
            //    column: "ProjectId");

            //migrationBuilder.CreateIndex(
            //    name: "Projects_IX_UserId",
            //    schema: "dbo",
            //    table: "Projects",
            //    column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Developers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");
        }
    }
}
