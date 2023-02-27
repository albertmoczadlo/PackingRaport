using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackingRaport.Persistance.Migrations
{
    public partial class RefactorPersistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raports_AspNetUsers_UserId",
                table: "Raports");

            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Containers_RaportId",
                table: "Containers");

            migrationBuilder.RenameColumn(
                name: "NumberContainer",
                table: "Containers",
                newName: "Type");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Raports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndProductionTime",
                table: "Raports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_RaportId",
                table: "Containers",
                column: "RaportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Raports_AspNetUsers_UserId",
                table: "Raports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raports_AspNetUsers_UserId",
                table: "Raports");

            migrationBuilder.DropIndex(
                name: "IX_Containers_RaportId",
                table: "Containers");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Containers",
                newName: "NumberContainer");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Raports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndProductionTime",
                table: "Raports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerId = table.Column<int>(type: "int", nullable: false),
                    Bath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cauldron = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tanks_Containers_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Containers_RaportId",
                table: "Containers",
                column: "RaportId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_ContainerId",
                table: "Tanks",
                column: "ContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Raports_AspNetUsers_UserId",
                table: "Raports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
