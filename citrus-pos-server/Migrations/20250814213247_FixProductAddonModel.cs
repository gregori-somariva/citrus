using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citrus.Migrations
{
    /// <inheritdoc />
    public partial class FixProductAddonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductAddons_ProductAddonId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductAddonId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductAddonId",
                table: "OrderItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductAddonId",
                table: "OrderItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductAddonId",
                table: "OrderItems",
                column: "ProductAddonId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductAddons_ProductAddonId",
                table: "OrderItems",
                column: "ProductAddonId",
                principalTable: "ProductAddons",
                principalColumn: "ProductAddonId");
        }
    }
}
