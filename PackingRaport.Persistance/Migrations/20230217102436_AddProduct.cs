using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackingRaport.Persistance.Migrations
{
    public partial class AddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_RaportId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RaportId",
                table: "Products",
                column: "RaportId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_RaportId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RaportId",
                table: "Products",
                column: "RaportId");
        }
    }
}
