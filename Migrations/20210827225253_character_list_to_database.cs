using Microsoft.EntityFrameworkCore.Migrations;

namespace pr.Migrations
{
    public partial class character_list_to_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "characters",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_characters_Userid",
                table: "characters",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_users_Userid",
                table: "characters",
                column: "Userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_users_Userid",
                table: "characters");

            migrationBuilder.DropIndex(
                name: "IX_characters_Userid",
                table: "characters");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "characters");
        }
    }
}
