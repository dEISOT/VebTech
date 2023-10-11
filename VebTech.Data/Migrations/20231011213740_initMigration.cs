using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VebTech.Data.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1d2a8348-203d-4135-ba65-491e134eaf68"), "User" },
                    { new Guid("670dbe30-9559-4769-9d7a-9586a6792c43"), "Support" },
                    { new Guid("a50b5ab1-dcb9-4afa-a18a-d5c2beae174e"), "SuperAdmin" },
                    { new Guid("a639ddb4-02e8-4e48-a261-e1e46b525a95"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "PasswordHash" },
                values: new object[,]
                {
                    { new Guid("cf4fa1ad-f8fc-4aaa-a9e7-b82baf8f7fb7"), 18, "SuperAdminAndAdmin@gmail.com", "SupportAndAdmin", "$2a$11$VJt9haQildwr6fGQshWPa.0HQlmjK1r7iGe0DXS6mutCJ3j2bbjOC" },
                    { new Guid("d30159c4-d99e-4ee0-ae00-686c3db430e4"), 18, "SuperAdmin@gmail.com", "SuperAdmin", "$2a$11$oVL9A6rynLrXQ5zJ9v6dz.dnhcGdvJmCSNH2XSJTe.Fp/HNXLlW1." },
                    { new Guid("e97dfc7d-e0e1-4d4b-9d16-14c0bdaccd66"), 18, "admin@gmail.com", "Admin", "$2a$11$JnL5poycc3YNwklfoilHLuSW2LBWDIdX4KyRchIzqwQi6NxyUE7/i" },
                    { new Guid("ef1a0d40-2d0e-488e-aa8d-b822d1a4296a"), 18, "user@gmail.com", "User", "$2a$11$rhe4VNKFX8Glsz/5E36rHeisum8bBa7XdBb8Bc/X4Ufc5Kw2uXDie" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("670dbe30-9559-4769-9d7a-9586a6792c43"), new Guid("cf4fa1ad-f8fc-4aaa-a9e7-b82baf8f7fb7") },
                    { new Guid("a639ddb4-02e8-4e48-a261-e1e46b525a95"), new Guid("cf4fa1ad-f8fc-4aaa-a9e7-b82baf8f7fb7") },
                    { new Guid("a50b5ab1-dcb9-4afa-a18a-d5c2beae174e"), new Guid("d30159c4-d99e-4ee0-ae00-686c3db430e4") },
                    { new Guid("a639ddb4-02e8-4e48-a261-e1e46b525a95"), new Guid("e97dfc7d-e0e1-4d4b-9d16-14c0bdaccd66") },
                    { new Guid("1d2a8348-203d-4135-ba65-491e134eaf68"), new Guid("ef1a0d40-2d0e-488e-aa8d-b822d1a4296a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
