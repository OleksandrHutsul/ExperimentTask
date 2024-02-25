using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperimentTask.Migrations
{
    /// <inheritdoc />
    public partial class addTwoFieldFromExperimentResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExperimentKey",
                table: "ExperimentResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ExperimentResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExperimentKey",
                table: "ExperimentResults");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ExperimentResults");
        }
    }
}
