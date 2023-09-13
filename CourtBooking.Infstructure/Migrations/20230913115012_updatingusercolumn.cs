using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourtBooking.Infstructure.Migrations
{
    /// <inheritdoc />
    public partial class updatingusercolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserMasters",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UserMasters",
                newName: "UserName");
        }
    }
}
