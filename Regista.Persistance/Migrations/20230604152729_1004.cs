using System;
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
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketStatus",
                table: "Tickets",
                newName: "TaskStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanedEnd",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanedStart",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PriorityStatus",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanedEnd",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PlanedStart",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PriorityStatus",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "Tickets",
                newName: "TicketStatus");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
