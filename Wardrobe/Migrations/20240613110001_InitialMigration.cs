using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairOfShoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsageLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WearCounter = table.Column<int>(type: "int", nullable: false),
                    WearDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PairOfShoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsageLog_PairOfShoes_PairOfShoesId",
                        column: x => x.PairOfShoesId,
                        principalTable: "PairOfShoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsageLog_PairOfShoesId",
                table: "UsageLog",
                column: "PairOfShoesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsageLog");

            migrationBuilder.DropTable(
                name: "PairOfShoes");
        }
    }
}
