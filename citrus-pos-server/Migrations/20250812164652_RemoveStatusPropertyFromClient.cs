using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citrus.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStatusPropertyFromClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Clients");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
