using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopFood.Migrations
{
    /// <inheritdoc />
    public partial class fifthMigrtation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "purchaseHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostumerAge = table.Column<int>(type: "int", nullable: false),
                    CostumerGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostumerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseHistories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaseHistories");
        }
    }
}
