using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperimentTask.Migrations
{
    /// <inheritdoc />
    public partial class deletetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperimentResults_ExperimentButtonColors_ExperimentButtonColorId",
                table: "ExperimentResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperimentResults_ExperimentPrices_ExperimentPriceId",
                table: "ExperimentResults");

            migrationBuilder.DropTable(
                name: "ExperimentButtonColors");

            migrationBuilder.DropTable(
                name: "ExperimentPrices");

            migrationBuilder.DropTable(
                name: "ButtonColors");

            migrationBuilder.DropTable(
                name: "PriceValues");

            migrationBuilder.DropIndex(
                name: "IX_ExperimentResults_ExperimentButtonColorId",
                table: "ExperimentResults");

            migrationBuilder.DropIndex(
                name: "IX_ExperimentResults_ExperimentPriceId",
                table: "ExperimentResults");

            migrationBuilder.DropColumn(
                name: "ExperimentButtonColorId",
                table: "ExperimentResults");

            migrationBuilder.DropColumn(
                name: "ExperimentPriceId",
                table: "ExperimentResults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperimentButtonColorId",
                table: "ExperimentResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExperimentPriceId",
                table: "ExperimentResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ButtonColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperimentButtonColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ButtonColorValueId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentButtonColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperimentButtonColors_ButtonColors_ButtonColorValueId",
                        column: x => x.ButtonColorValueId,
                        principalTable: "ButtonColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperimentPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceValueId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperimentPrices_PriceValues_PriceValueId",
                        column: x => x.PriceValueId,
                        principalTable: "PriceValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentResults_ExperimentButtonColorId",
                table: "ExperimentResults",
                column: "ExperimentButtonColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentResults_ExperimentPriceId",
                table: "ExperimentResults",
                column: "ExperimentPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentButtonColors_ButtonColorValueId",
                table: "ExperimentButtonColors",
                column: "ButtonColorValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentPrices_PriceValueId",
                table: "ExperimentPrices",
                column: "PriceValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperimentResults_ExperimentButtonColors_ExperimentButtonColorId",
                table: "ExperimentResults",
                column: "ExperimentButtonColorId",
                principalTable: "ExperimentButtonColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperimentResults_ExperimentPrices_ExperimentPriceId",
                table: "ExperimentResults",
                column: "ExperimentPriceId",
                principalTable: "ExperimentPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
