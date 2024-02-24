using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WearCounter");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PairOfShoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trousers",
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trousers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trousers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PairOfShoes_UserId",
                table: "PairOfShoes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trousers_UserId",
                table: "Trousers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PairOfShoes_User_UserId",
                table: "PairOfShoes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PairOfShoes_User_UserId",
                table: "PairOfShoes");

            migrationBuilder.DropTable(
                name: "Trousers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_PairOfShoes_UserId",
                table: "PairOfShoes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PairOfShoes");

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
    }
}
