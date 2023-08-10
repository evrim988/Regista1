using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regista.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _1004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastDate",
                table: "Actions",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Actions",
                newName: "LastDate");
        }
    }
}
