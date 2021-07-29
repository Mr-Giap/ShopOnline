using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.DataEF.Migrations
{
    public partial class intcst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameAscii",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BillId",
                table: "Categories",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Bills_BillId",
                table: "Categories",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Bills_BillId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_BillId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameAscii",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Categories");
        }
    }
}
