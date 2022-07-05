using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingAPI.Migrations
{
    public partial class sixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "leave_time",
                table: "bookings",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "entry_time",
                table: "bookings",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "booking_date",
                table: "bookings",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "leave_time",
                table: "bookings",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "entry_time",
                table: "bookings",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "booking_date",
                table: "bookings",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
