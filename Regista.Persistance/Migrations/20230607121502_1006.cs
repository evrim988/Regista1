using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regista.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _1006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Customers_CustomerID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Tasks",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "Tasks",
                newName: "taskStatus");

            migrationBuilder.RenameColumn(
                name: "ResponsibleID",
                table: "Tasks",
                newName: "responsibleID");

            migrationBuilder.RenameColumn(
                name: "PriorityStatus",
                table: "Tasks",
                newName: "priorityStatus");

            migrationBuilder.RenameColumn(
                name: "PlanedStart",
                table: "Tasks",
                newName: "planedStart");

            migrationBuilder.RenameColumn(
                name: "PlanedEnd",
                table: "Tasks",
                newName: "planedEnd");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Tasks",
                newName: "customerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_UserID",
                table: "Tasks",
                newName: "IX_Tasks_userID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CustomerID",
                table: "Tasks",
                newName: "IX_Tasks_customerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Customers_customerID",
                table: "Tasks",
                column: "customerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_userID",
                table: "Tasks",
                column: "userID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Customers_customerID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_userID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Tasks",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "taskStatus",
                table: "Tasks",
                newName: "TaskStatus");

            migrationBuilder.RenameColumn(
                name: "responsibleID",
                table: "Tasks",
                newName: "ResponsibleID");

            migrationBuilder.RenameColumn(
                name: "priorityStatus",
                table: "Tasks",
                newName: "PriorityStatus");

            migrationBuilder.RenameColumn(
                name: "planedStart",
                table: "Tasks",
                newName: "PlanedStart");

            migrationBuilder.RenameColumn(
                name: "planedEnd",
                table: "Tasks",
                newName: "PlanedEnd");

            migrationBuilder.RenameColumn(
                name: "customerID",
                table: "Tasks",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_userID",
                table: "Tasks",
                newName: "IX_Tasks_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_customerID",
                table: "Tasks",
                newName: "IX_Tasks_CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Customers_CustomerID",
                table: "Tasks",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserID",
                table: "Tasks",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
