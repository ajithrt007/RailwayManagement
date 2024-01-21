using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrainSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FromTo",
                table: "Trains",
                newName: "TrainNumber");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Trains",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Trains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "Trains",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Trains");

            migrationBuilder.RenameColumn(
                name: "TrainNumber",
                table: "Trains",
                newName: "FromTo");
        }
    }
}
