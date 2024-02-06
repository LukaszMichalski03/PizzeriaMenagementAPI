using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class nullableCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerDataId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerDataId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerDataId",
                table: "Orders",
                column: "CustomerDataId",
                unique: true,
                filter: "[CustomerDataId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerDataId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerDataId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerDataId",
                table: "Orders",
                column: "CustomerDataId",
                unique: true);
        }
    }
}
