using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddCartFieldAndItensCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "ItemCarts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalItemAmount",
                table: "ItemCarts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "ItemCarts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Branch",
                table: "Carts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "Carts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSaleAmount",
                table: "Carts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSaleDiscounts",
                table: "Carts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "ItemCarts");

            migrationBuilder.DropColumn(
                name: "TotalItemAmount",
                table: "ItemCarts");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ItemCarts");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "TotalSaleAmount",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "TotalSaleDiscounts",
                table: "Carts");
        }
    }
}
