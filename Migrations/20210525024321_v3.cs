using Microsoft.EntityFrameworkCore.Migrations;

namespace data_keeping_system_for_petrol_pump.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "tblSales",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "tblCustomer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "tblSales");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "tblCustomer");
        }
    }
}
