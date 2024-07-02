using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETMeetApp.Migrations
{
    /// <inheritdoc />
    public partial class filePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Homeworks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Homeworks");
        }
    }
}
