using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackingRaport.Persistance.Migrations
{
    public partial class ChangeRequaireUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raports_AspNetUsers_UserId",
                table: "Raports");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Raports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Raports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
