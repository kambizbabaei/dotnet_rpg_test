using Microsoft.EntityFrameworkCore.Migrations;

namespace pr.Migrations
{
    public partial class models_restructured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_Users_ownerid",
                table: "characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Token_Users_Userid",
                table: "Token");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Token",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Token_Userid",
                table: "Token",
                newName: "IX_Token_UserId");

            migrationBuilder.RenameColumn(
                name: "ownerid",
                table: "characters",
                newName: "ownerId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "characters",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_characters_ownerid",
                table: "characters",
                newName: "IX_characters_ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_Users_ownerId",
                table: "characters",
                column: "ownerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Users_UserId",
                table: "Token",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_Users_ownerId",
                table: "characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Token_Users_UserId",
                table: "Token");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Token",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_Token_UserId",
                table: "Token",
                newName: "IX_Token_Userid");

            migrationBuilder.RenameColumn(
                name: "ownerId",
                table: "characters",
                newName: "ownerid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "characters",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_characters_ownerId",
                table: "characters",
                newName: "IX_characters_ownerid");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_Users_ownerid",
                table: "characters",
                column: "ownerid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Users_Userid",
                table: "Token",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
