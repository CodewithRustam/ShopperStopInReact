using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopperStopInReact_Shared.Migrations
{
    public partial class newcategorycol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Category");
        }
    }
}
