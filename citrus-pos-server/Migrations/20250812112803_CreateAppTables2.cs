using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citrus.Migrations
{
    /// <inheritdoc />
    public partial class CreateAppTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAddons_OrderItems_OrderItemId",
                table: "ProductAddons");

            migrationBuilder.DropIndex(
                name: "IX_ProductAddons_OrderItemId",
                table: "ProductAddons");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "ProductAddons");

            migrationBuilder.CreateTable(
                name: "OrderItemProductAddon",
                columns: table => new
                {
                    OrderItemsOrderItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductAddonsProductAddonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemProductAddon", x => new { x.OrderItemsOrderItemId, x.ProductAddonsProductAddonId });
                    table.ForeignKey(
                        name: "FK_OrderItemProductAddon_OrderItems_OrderItemsOrderItemId",
                        column: x => x.OrderItemsOrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemProductAddon_ProductAddons_ProductAddonsProductAddonId",
                        column: x => x.ProductAddonsProductAddonId,
                        principalTable: "ProductAddons",
                        principalColumn: "ProductAddonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemProductAddon_ProductAddonsProductAddonId",
                table: "OrderItemProductAddon",
                column: "ProductAddonsProductAddonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemProductAddon");

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "ProductAddons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAddons_OrderItemId",
                table: "ProductAddons",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAddons_OrderItems_OrderItemId",
                table: "ProductAddons",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "OrderItemId");
        }
    }
}
