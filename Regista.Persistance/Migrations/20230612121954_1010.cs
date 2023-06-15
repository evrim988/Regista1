using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regista.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _1010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketContent",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TicketTitle",
                table: "Tasks",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Tasks",
                newName: "TicketTitle");

            migrationBuilder.AddColumn<string>(
                name: "TicketContent",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
