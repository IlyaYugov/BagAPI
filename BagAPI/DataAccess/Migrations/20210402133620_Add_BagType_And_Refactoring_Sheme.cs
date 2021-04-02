using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.Migrations
{
    public partial class Add_BagType_And_Refactoring_Sheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_User_SourceUserId",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "SourceUserId",
                table: "Request",
                newName: "TransfererUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_SourceUserId",
                table: "Request",
                newName: "IX_Request_TransfererUserId");

            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                table: "Request",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BagType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestTypeId",
                table: "Request",
                column: "RequestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_BagType_RequestTypeId",
                table: "Request",
                column: "RequestTypeId",
                principalTable: "BagType",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_BagType_RequestTypeId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_User_TransfererUserId",
                table: "Request");

            migrationBuilder.DropTable(
                name: "BagType");

            migrationBuilder.DropIndex(
                name: "IX_Request_RequestTypeId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "TransfererUserId",
                table: "Request",
                newName: "SourceUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_TransfererUserId",
                table: "Request",
                newName: "IX_Request_SourceUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_User_SourceUserId",
                table: "Request",
                column: "SourceUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
