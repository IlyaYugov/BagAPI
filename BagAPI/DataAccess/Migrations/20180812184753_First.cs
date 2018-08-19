using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccess.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BagType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessengerType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessengerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descriprion = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bag_BagType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "BagType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    SourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_City_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_City_SourceId",
                        column: x => x.SourceId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMessenger",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    MessengerTypeId = table.Column<int>(nullable: false),
                    Contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessenger", x => new { x.UserId, x.MessengerTypeId });
                    table.ForeignKey(
                        name: "FK_UserMessenger_MessengerType_MessengerTypeId",
                        column: x => x.MessengerTypeId,
                        principalTable: "MessengerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMessenger_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BagId = table.Column<int>(nullable: false),
                    Descrition = table.Column<string>(nullable: true),
                    FlightId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    SenderId = table.Column<int>(nullable: true),
                    SenderUserId = table.Column<int>(nullable: false),
                    SourceId = table.Column<int>(nullable: true),
                    SourceUserId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_Bag_BagId",
                        column: x => x.BagId,
                        principalTable: "Bag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_User_SenderId",
                        column: x => x.SenderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_User_SourceId",
                        column: x => x.SourceId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_RequestStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "RequestStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bag_TypeId",
                table: "Bag",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationId",
                table: "Flight",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_SourceId",
                table: "Flight",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_BagId",
                table: "Request",
                column: "BagId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_FlightId",
                table: "Request",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_SenderId",
                table: "Request",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_SourceId",
                table: "Request",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_StatusId",
                table: "Request",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessenger_MessengerTypeId",
                table: "UserMessenger",
                column: "MessengerTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "UserMessenger");

            migrationBuilder.DropTable(
                name: "Bag");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "RequestStatus");

            migrationBuilder.DropTable(
                name: "MessengerType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BagType");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
