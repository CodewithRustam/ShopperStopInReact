using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopperStopInReact_Shared.Migrations
{
    public partial class updateOtpVerificationLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "OtpVerificationLog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OtpVerificationLog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
