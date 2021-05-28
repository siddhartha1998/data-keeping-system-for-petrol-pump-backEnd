using Microsoft.EntityFrameworkCore.Migrations;

namespace data_keeping_system_for_petrol_pump.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblSales_tblCustomer_Customerid",
                table: "tblSales");

            migrationBuilder.RenameColumn(
                name: "Customerid",
                table: "tblSales",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_tblSales_Customerid",
                table: "tblSales",
                newName: "IX_tblSales_customerId");

            migrationBuilder.AlterColumn<int>(
                name: "customerId",
                table: "tblSales",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblSales_tblCustomer_customerId",
                table: "tblSales",
                column: "customerId",
                principalTable: "tblCustomer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblSales_tblCustomer_customerId",
                table: "tblSales");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "tblSales",
                newName: "Customerid");

            migrationBuilder.RenameIndex(
                name: "IX_tblSales_customerId",
                table: "tblSales",
                newName: "IX_tblSales_Customerid");

            migrationBuilder.AlterColumn<int>(
                name: "Customerid",
                table: "tblSales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tblSales_tblCustomer_Customerid",
                table: "tblSales",
                column: "Customerid",
                principalTable: "tblCustomer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
