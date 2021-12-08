using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeMaster.Migrations
{
    public partial class anotherclassfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderManagerId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderManagerId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderManagerId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RewardValue",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IsPaid", "IsServed" },
                values: new object[] { 1, 1, true, true });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IsPaid", "IsServed" },
                values: new object[] { 2, 2, false, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "OrderManagerId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GrandTotal",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RewardValue",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderManagerId1",
                table: "Products",
                column: "OrderManagerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderManagerId1",
                table: "Products",
                column: "OrderManagerId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
