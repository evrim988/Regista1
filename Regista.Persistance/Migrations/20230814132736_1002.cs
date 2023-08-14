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
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_requests_RequestID",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_projectNotes_Customers_CustomerID",
                table: "projectNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_projectNotes_Projects_ProjectID",
                table: "projectNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_Customers_CustomerID",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_Modules_ModulesID",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_Projects_ProjectID",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_requests_RequestID",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_requests",
                table: "requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectNotes",
                table: "projectNotes");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "requests");

            migrationBuilder.RenameTable(
                name: "requests",
                newName: "Requests");

            migrationBuilder.RenameTable(
                name: "projectNotes",
                newName: "ProjectNotes");

            migrationBuilder.RenameIndex(
                name: "IX_requests_ProjectID",
                table: "Requests",
                newName: "IX_Requests_ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_requests_ModulesID",
                table: "Requests",
                newName: "IX_Requests_ModulesID");

            migrationBuilder.RenameIndex(
                name: "IX_requests_CustomerID",
                table: "Requests",
                newName: "IX_Requests_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_projectNotes_ProjectID",
                table: "ProjectNotes",
                newName: "IX_ProjectNotes_ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_projectNotes_CustomerID",
                table: "ProjectNotes",
                newName: "IX_ProjectNotes_CustomerID");

            migrationBuilder.AlterColumn<string>(
                name: "PictureURL",
                table: "Requests",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PageURL",
                table: "Requests",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "NotificationType",
                table: "Requests",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Requests",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectNotes",
                table: "ProjectNotes",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Requests_RequestID",
                table: "Actions",
                column: "RequestID",
                principalTable: "Requests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectNotes_Customers_CustomerID",
                table: "ProjectNotes",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectNotes_Projects_ProjectID",
                table: "ProjectNotes",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Customers_CustomerID",
                table: "Requests",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Modules_ModulesID",
                table: "Requests",
                column: "ModulesID",
                principalTable: "Modules",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Projects_ProjectID",
                table: "Requests",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Requests_RequestID",
                table: "Tasks",
                column: "RequestID",
                principalTable: "Requests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Requests_RequestID",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectNotes_Customers_CustomerID",
                table: "ProjectNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectNotes_Projects_ProjectID",
                table: "ProjectNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Customers_CustomerID",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Modules_ModulesID",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Projects_ProjectID",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Requests_RequestID",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectNotes",
                table: "ProjectNotes");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "requests");

            migrationBuilder.RenameTable(
                name: "ProjectNotes",
                newName: "projectNotes");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ProjectID",
                table: "requests",
                newName: "IX_requests_ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ModulesID",
                table: "requests",
                newName: "IX_requests_ModulesID");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_CustomerID",
                table: "requests",
                newName: "IX_requests_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectNotes_ProjectID",
                table: "projectNotes",
                newName: "IX_projectNotes_ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectNotes_CustomerID",
                table: "projectNotes",
                newName: "IX_projectNotes_CustomerID");

            migrationBuilder.UpdateData(
                table: "requests",
                keyColumn: "PictureURL",
                keyValue: null,
                column: "PictureURL",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PictureURL",
                table: "requests",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "requests",
                keyColumn: "PageURL",
                keyValue: null,
                column: "PageURL",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PageURL",
                table: "requests",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "requests",
                keyColumn: "NotificationType",
                keyValue: null,
                column: "NotificationType",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "NotificationType",
                table: "requests",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "requests",
                keyColumn: "Category",
                keyValue: null,
                column: "Category",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "requests",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "requests",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_requests",
                table: "requests",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectNotes",
                table: "projectNotes",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_requests_RequestID",
                table: "Actions",
                column: "RequestID",
                principalTable: "requests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projectNotes_Customers_CustomerID",
                table: "projectNotes",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_projectNotes_Projects_ProjectID",
                table: "projectNotes",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_Customers_CustomerID",
                table: "requests",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_Modules_ModulesID",
                table: "requests",
                column: "ModulesID",
                principalTable: "Modules",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_Projects_ProjectID",
                table: "requests",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_requests_RequestID",
                table: "Tasks",
                column: "RequestID",
                principalTable: "requests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
