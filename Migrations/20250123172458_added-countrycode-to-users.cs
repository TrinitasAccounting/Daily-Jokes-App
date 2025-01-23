using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyJokesApp.Migrations
{
    /// <inheritdoc />
    public partial class addedcountrycodetousers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryCode",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Users");
        }
    }
}
