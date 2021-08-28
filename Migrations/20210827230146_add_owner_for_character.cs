using Microsoft.EntityFrameworkCore.Migrations;

namespace pr.Migrations
{
    public partial class add_owner_for_character : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_users_Userid",
                table: "characters");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "characters",
                newName: "ownerid");

            migrationBuilder.RenameIndex(
                name: "IX_characters_Userid",
                table: "characters",
                newName: "IX_characters_ownerid");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_users_ownerid",
                table: "characters",
                column: "ownerid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_users_ownerid",
                table: "characters");

            migrationBuilder.RenameColumn(
                name: "ownerid",
                table: "characters",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_characters_ownerid",
                table: "characters",
                newName: "IX_characters_Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_users_Userid",
                table: "characters",
                column: "Userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
