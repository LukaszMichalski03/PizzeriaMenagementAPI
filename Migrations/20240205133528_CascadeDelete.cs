﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerDataId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerDataId",
                table: "Orders",
                column: "CustomerDataId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerDataId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerDataId",
                table: "Orders",
                column: "CustomerDataId");
        }
    }
}
