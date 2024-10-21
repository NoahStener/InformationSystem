using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AmountToEventModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountIn",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "AmountOut",
                table: "Drivers");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountIn",
                table: "Events",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOut",
                table: "Events",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountIn",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AmountOut",
                table: "Events");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountIn",
                table: "Drivers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOut",
                table: "Drivers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
