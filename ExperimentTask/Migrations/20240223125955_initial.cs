using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperimentTask.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonColorValueId = table.Column<int>(type: "int", nullable: false)
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
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceValueId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ExperimentResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperimentPriceId = table.Column<int>(type: "int", nullable: false),
                    ExperimentButtonColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperimentResults_ExperimentButtonColors_ExperimentButtonColorId",
                        column: x => x.ExperimentButtonColorId,
                        principalTable: "ExperimentButtonColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperimentResults_ExperimentPrices_ExperimentPriceId",
                        column: x => x.ExperimentPriceId,
                        principalTable: "ExperimentPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentButtonColors_ButtonColorValueId",
                table: "ExperimentButtonColors",
                column: "ButtonColorValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentPrices_PriceValueId",
                table: "ExperimentPrices",
                column: "PriceValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentResults_ExperimentButtonColorId",
                table: "ExperimentResults",
                column: "ExperimentButtonColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentResults_ExperimentPriceId",
                table: "ExperimentResults",
                column: "ExperimentPriceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperimentResults");

            migrationBuilder.DropTable(
                name: "ExperimentButtonColors");

            migrationBuilder.DropTable(
                name: "ExperimentPrices");

            migrationBuilder.DropTable(
                name: "ButtonColors");

            migrationBuilder.DropTable(
                name: "PriceValues");
        }
    }
}
