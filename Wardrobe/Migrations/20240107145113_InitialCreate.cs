using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PairOfShoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairOfShoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WearCounter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Counter = table.Column<int>(type: "int", nullable: false),
                    PairOfShoesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WearCounter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WearCounter_PairOfShoes_PairOfShoesId",
                        column: x => x.PairOfShoesId,
                        principalTable: "PairOfShoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WearCounter_PairOfShoesId",
                table: "WearCounter",
                column: "PairOfShoesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WearCounter");

            migrationBuilder.DropTable(
                name: "PairOfShoes");
        }
    }
}
