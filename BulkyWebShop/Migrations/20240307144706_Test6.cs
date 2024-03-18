using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWebShop.Migrations
{
    /// <inheritdoc />
    public partial class Test6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Test",
                table: "Categories",
                newName: "TestVal");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "TestVal",
                value: 12);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestVal",
                table: "Categories",
                newName: "Test");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "Test",
                value: 22);
        }
    }
}
