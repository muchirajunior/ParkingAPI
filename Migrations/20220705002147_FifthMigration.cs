using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingAPI.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "paid",
                table: "bookings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "bookings",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paid",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "price",
                table: "bookings");
        }
    }
}
