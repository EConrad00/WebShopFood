using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopFood.Migrations
{
    /// <inheritdoc />
    public partial class thirdMigrtation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductionAndExpirationDates_ProductionAndExpirationDateId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductionAndExpirationDates");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductionAndExpirationDateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductionAndExpirationDateId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ExpirationDate",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductionDate",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductionAndExpirationDateId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductionAndExpirationDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionAndExpirationDates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductionAndExpirationDateId",
                table: "Products",
                column: "ProductionAndExpirationDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductionAndExpirationDates_ProductionAndExpirationDateId",
                table: "Products",
                column: "ProductionAndExpirationDateId",
                principalTable: "ProductionAndExpirationDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
