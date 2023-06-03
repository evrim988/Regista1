using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regista.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _1002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjeAçıklaması",
                table: "Projects",
                newName: "ProjectName");

            migrationBuilder.RenameColumn(
                name: "ProjeAdı",
                table: "Projects",
                newName: "ProjectDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Projects",
                newName: "ProjeAçıklaması");

            migrationBuilder.RenameColumn(
                name: "ProjectDescription",
                table: "Projects",
                newName: "ProjeAdı");
        }
    }
}
