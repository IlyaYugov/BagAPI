using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class change_nullable_keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BagRequest_User_SenderUserId",
                table: "BagRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BagRequest_User_TransfererUserId",
                table: "BagRequest");

            migrationBuilder.AlterColumn<int>(
                name: "TransfererUserId",
                table: "BagRequest",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "SenderUserId",
                table: "BagRequest",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_BagRequest_User_SenderUserId",
                table: "BagRequest",
                column: "SenderUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BagRequest_User_TransfererUserId",
                table: "BagRequest",
                column: "TransfererUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BagRequest_User_SenderUserId",
                table: "BagRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BagRequest_User_TransfererUserId",
                table: "BagRequest");

            migrationBuilder.AlterColumn<int>(
                name: "TransfererUserId",
                table: "BagRequest",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SenderUserId",
                table: "BagRequest",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
    }
}
