using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTicketSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FromTo",
                table: "Tickets",
                newName: "To");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Tickets",
                newName: "FromTo");
        }
    }
}
