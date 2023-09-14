using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourtBooking.Infstructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTenniscourtTableforAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Availbility",
                table: "TennisCourts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availbility",
                table: "TennisCourts");
        }
    }
}
