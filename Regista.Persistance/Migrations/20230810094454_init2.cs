using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regista.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestID",
                table: "Actions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Actions_RequestID",
                table: "Actions",
                column: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_requests_RequestID",
                table: "Actions",
                column: "RequestID",
                principalTable: "requests",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_requests_RequestID",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_RequestID",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "Actions");
        }
    }
}
