using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_FlightId",
                table: "Request");

            migrationBuilder.AddColumn<byte[]>(
                name: "TicketPhoto",
                table: "Flight",
                type: "bytea",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_FlightId",
                table: "Request",
                column: "FlightId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_FlightId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "TicketPhoto",
                table: "Flight");

            migrationBuilder.CreateIndex(
                name: "IX_Request_FlightId",
                table: "Request",
                column: "FlightId");
        }
    }
}
