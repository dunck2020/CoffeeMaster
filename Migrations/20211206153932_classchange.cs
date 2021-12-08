using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeMaster.Migrations
{
    public partial class classchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_OrderCustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderCustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCustomerId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderCustomerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderCustomerId",
                table: "Orders",
                column: "OrderCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_OrderCustomerId",
                table: "Orders",
                column: "OrderCustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
