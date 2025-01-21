using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopFood.Migrations
{
    /// <inheritdoc />
    public partial class secondMigrtation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductionAndExpirationDates_ProducerAndExpirationDateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProdAExpDateId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProducerAndExpirationDateId",
                table: "Products",
                newName: "ProductionAndExpirationDateId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProducerAndExpirationDateId",
                table: "Products",
                newName: "IX_Products_ProductionAndExpirationDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductionAndExpirationDates_ProductionAndExpirationDateId",
                table: "Products",
                column: "ProductionAndExpirationDateId",
                principalTable: "ProductionAndExpirationDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductionAndExpirationDates_ProductionAndExpirationDateId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductionAndExpirationDateId",
                table: "Products",
                newName: "ProducerAndExpirationDateId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductionAndExpirationDateId",
                table: "Products",
                newName: "IX_Products_ProducerAndExpirationDateId");

            migrationBuilder.AddColumn<int>(
                name: "ProdAExpDateId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductionAndExpirationDates_ProducerAndExpirationDateId",
                table: "Products",
                column: "ProducerAndExpirationDateId",
                principalTable: "ProductionAndExpirationDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
