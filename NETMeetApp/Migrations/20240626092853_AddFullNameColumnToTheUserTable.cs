using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETMeetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFullNameColumnToTheUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "AspNetUsers",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "Country");
        }
    }
}
