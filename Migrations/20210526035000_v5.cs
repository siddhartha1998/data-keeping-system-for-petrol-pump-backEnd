using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data_keeping_system_for_petrol_pump.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "tblSales",
                newName: "total");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "tblSales",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "tblSales");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "tblSales",
                newName: "Total");
        }
    }
}
