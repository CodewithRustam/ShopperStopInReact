using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopperStopInReact_Shared.Migrations
{
    public partial class changecol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "AddToCartItems",
                newName: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "AddToCartItems",
                newName: "ProductID");
        }
    }
}
