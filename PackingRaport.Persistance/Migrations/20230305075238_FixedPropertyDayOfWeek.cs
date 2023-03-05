using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackingRaport.Persistance.Migrations
{
    public partial class FixedPropertyDayOfWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Raports");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Raports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Raports");

            migrationBuilder.AddColumn<DateTime>(
                name: "DayOfWeek",
                table: "Raports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
