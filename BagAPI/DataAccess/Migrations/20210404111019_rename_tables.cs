using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class rename_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Bag_BagId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_BagType_RequestTypeId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Flight_FlightId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestStatus_RequestStatusId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_User_SenderUserId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_User_TransfererUserId",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatus",
                table: "RequestStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BagType",
                table: "BagType");

            migrationBuilder.RenameTable(
                name: "RequestStatus",
                newName: "BagRequestStatus");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "BagRequest");

            migrationBuilder.RenameTable(
                name: "BagType",
                newName: "BagRequestType");

            migrationBuilder.RenameIndex(
                name: "IX_Request_TransfererUserId",
                table: "BagRequest",
                newName: "IX_BagRequest_TransfererUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_SenderUserId",
                table: "BagRequest",
                newName: "IX_BagRequest_SenderUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_RequestTypeId",
                table: "BagRequest",
                newName: "IX_BagRequest_RequestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_RequestStatusId",
                table: "BagRequest",
                newName: "IX_BagRequest_RequestStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_FlightId",
                table: "BagRequest",
                newName: "IX_BagRequest_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_BagId",
                table: "BagRequest",
                newName: "IX_BagRequest_BagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BagRequestStatus",
                table: "BagRequestStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BagRequest",
                table: "BagRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BagRequestType",
                table: "BagRequestType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BagRequest_Bag_BagId",
                table: "BagRequest",
                column: "BagId",
                principalTable: "Bag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BagRequest_BagRequestStatus_RequestStatusId",
                table: "BagRequest",
                column: "RequestStatusId",
                principalTable: "BagRequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BagRequest_BagRequestType_RequestTypeId",
                table: "BagRequest",
                column: "RequestTypeId",
                principalTable: "BagRequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BagRequest_Flight_FlightId",
                table: "BagRequest",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BagRequest_User_SenderUserId",
                table: "BagRequest",
                column: "SenderUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BagRequest_User_TransfererUserId",
                table: "BagRequest",
                column: "TransfererUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BagRequest_Bag_BagId",
                table: "BagRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BagRequest_BagRequestStatus_RequestStatusId",
                table: "BagRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BagRequest_BagRequestType_RequestTypeId",
                table: "BagRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BagRequest_Flight_FlightId",
                table: "BagRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BagRequest_User_SenderUserId",
                table: "BagRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BagRequest_User_TransfererUserId",
                table: "BagRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BagRequestType",
                table: "BagRequestType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BagRequestStatus",
                table: "BagRequestStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BagRequest",
                table: "BagRequest");

            migrationBuilder.RenameTable(
                name: "BagRequestType",
                newName: "BagType");

            migrationBuilder.RenameTable(
                name: "BagRequestStatus",
                newName: "RequestStatus");

            migrationBuilder.RenameTable(
                name: "BagRequest",
                newName: "Request");

            migrationBuilder.RenameIndex(
                name: "IX_BagRequest_TransfererUserId",
                table: "Request",
                newName: "IX_Request_TransfererUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BagRequest_SenderUserId",
                table: "Request",
                newName: "IX_Request_SenderUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BagRequest_RequestTypeId",
                table: "Request",
                newName: "IX_Request_RequestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BagRequest_RequestStatusId",
                table: "Request",
                newName: "IX_Request_RequestStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_BagRequest_FlightId",
                table: "Request",
                newName: "IX_Request_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_BagRequest_BagId",
                table: "Request",
                newName: "IX_Request_BagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BagType",
                table: "BagType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatus",
                table: "RequestStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Bag_BagId",
                table: "Request",
                column: "BagId",
                principalTable: "Bag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_BagType_RequestTypeId",
                table: "Request",
                column: "RequestTypeId",
                principalTable: "BagType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Flight_FlightId",
                table: "Request",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestStatus_RequestStatusId",
                table: "Request",
                column: "RequestStatusId",
                principalTable: "RequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_User_SenderUserId",
                table: "Request",
                column: "SenderUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_User_TransfererUserId",
                table: "Request",
                column: "TransfererUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
