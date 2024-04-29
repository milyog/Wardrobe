using System;
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
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PairOfShoes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "WearCounter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimesWorn = table.Column<int>(type: "int", nullable: false),
                    WearDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PairOfShoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PairOfShoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
