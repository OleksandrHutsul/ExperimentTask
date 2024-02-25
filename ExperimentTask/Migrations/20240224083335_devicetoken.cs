using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperimentTask.Migrations
{
    /// <inheritdoc />
    public partial class devicetoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceToken",
                table: "ExperimentResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceToken",
                table: "ExperimentResults");
        }
    }
}
