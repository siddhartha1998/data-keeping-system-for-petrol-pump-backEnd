using Microsoft.EntityFrameworkCore.Migrations;

namespace data_keeping_system_for_petrol_pump.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblSales",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    rate = table.Column<float>(nullable: false),
                    Total = table.Column<float>(nullable: false),
                    remarks = table.Column<string>(nullable: true),
                    Customerid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSales", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblSales_tblCustomer_Customerid",
                        column: x => x.Customerid,
                        principalTable: "tblCustomer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblSales_Customerid",
                table: "tblSales",
                column: "Customerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblSales");

            migrationBuilder.DropTable(
                name: "tblCustomer");
        }
    }
}
