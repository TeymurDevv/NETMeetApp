using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETMeetApp.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAspNetRoleClaims_StudentAspNetRoles_RoleId",
                table: "StudentAspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAspNetUserClaims_AspNetUsers_UserId",
                table: "StudentAspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAspNetUserLogins_AspNetUsers_UserId",
                table: "StudentAspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAspNetUserRoles_AspNetUsers_UserId",
                table: "StudentAspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAspNetUserRoles_StudentAspNetRoles_RoleId",
                table: "StudentAspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAspNetUserTokens_AspNetUsers_UserId",
                table: "StudentAspNetUserTokens");

            migrationBuilder.DropTable(
                name: "StudentAspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAspNetUserTokens",
                table: "StudentAspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAspNetUserRoles",
                table: "StudentAspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAspNetUserLogins",
                table: "StudentAspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAspNetUserClaims",
                table: "StudentAspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAspNetRoles",
                table: "StudentAspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAspNetRoleClaims",
                table: "StudentAspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "StudentAspNetUserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "StudentAspNetUserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "StudentAspNetUserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "StudentAspNetUserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "StudentAspNetRoles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "StudentAspNetRoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "StudentAspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "StudentAspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "StudentAspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "StudentAspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "StudentAspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "StudentAspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "StudentAspNetUserRoles",
                newName: "IX_StudentAspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "StudentAspNetUserLogins",
                newName: "IX_StudentAspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "StudentAspNetUserClaims",
                newName: "IX_StudentAspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "StudentAspNetRoleClaims",
                newName: "IX_StudentAspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAspNetUserTokens",
                table: "StudentAspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAspNetUserRoles",
                table: "StudentAspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAspNetUserLogins",
                table: "StudentAspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAspNetUserClaims",
                table: "StudentAspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAspNetRoles",
                table: "StudentAspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAspNetRoleClaims",
                table: "StudentAspNetRoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentAspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BioGraphy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAspNetUsers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAspNetRoleClaims_StudentAspNetRoles_RoleId",
                table: "StudentAspNetRoleClaims",
                column: "RoleId",
                principalTable: "StudentAspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAspNetUserClaims_AspNetUsers_UserId",
                table: "StudentAspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAspNetUserLogins_AspNetUsers_UserId",
                table: "StudentAspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAspNetUserRoles_AspNetUsers_UserId",
                table: "StudentAspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAspNetUserRoles_StudentAspNetRoles_RoleId",
                table: "StudentAspNetUserRoles",
                column: "RoleId",
                principalTable: "StudentAspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAspNetUserTokens_AspNetUsers_UserId",
                table: "StudentAspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
