using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayManagement.Migrations
{
    /// <inheritdoc />
    public partial class TotalChangeSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Trains",
                newName: "Duration");

            migrationBuilder.AddColumn<int>(
                name: "TrainId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Trains",
                newName: "Time");
        }
    }
}
