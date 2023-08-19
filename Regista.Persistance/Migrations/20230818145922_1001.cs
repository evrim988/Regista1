using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regista.Persistance.Migrations
{
    public partial class _1001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Modules_ModulesID",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "ModulesID",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Requests",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Modules_ModulesID",
                table: "Requests",
                column: "ModulesID",
                principalTable: "Modules",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Modules_ModulesID",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "ModulesID",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Requests",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Modules_ModulesID",
                table: "Requests",
                column: "ModulesID",
                principalTable: "Modules",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
