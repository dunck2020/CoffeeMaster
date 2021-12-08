using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeMaster.Migrations
{
    public partial class initialcreateseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Phone", "Rewards" },
                values: new object[,]
                {
                    { 1, "osnake@gmail.com", "Olivia Snakeroot", "231-555-2312", 12 },
                    { 2, "jake@gmail.com", "Jake Martian", "231-555-4512", 3 },
                    { 3, "jmisth@gmail.com", "Jan Smith", "231-555-4121", 55 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "OrderManagerId", "OrderManagerId1", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Fresh brew from BRC", "Lg Coffee", null, null, 3.00m, 0 },
                    { 2, "Fresh brew from BRC", "Md Coffee", null, null, 2.00m, 0 },
                    { 3, "Fresh brew from BRC", "Sm Coffee", null, null, 1.00m, 0 },
                    { 4, "Delicious suger glazed treat", "Blueberry Muffin", null, null, 2.00m, 1 },
                    { 5, "Soft Cotton-Blend", "Sm T-Shirt", null, null, 20.00m, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
