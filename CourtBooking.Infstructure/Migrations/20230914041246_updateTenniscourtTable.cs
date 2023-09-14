using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourtBooking.Infstructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTenniscourtTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TennisCourts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "TennisCourts");
        }
    }
}
