using Microsoft.EntityFrameworkCore.Migrations;

namespace pr.Migrations
{
    public partial class added_owned_weapon_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedWeapon_characters_characterId",
                table: "OwnedWeapon");

            migrationBuilder.DropIndex(
                name: "IX_OwnedWeapon_characterId",
                table: "OwnedWeapon");

            migrationBuilder.DropColumn(
                name: "characterId",
                table: "OwnedWeapon");

            migrationBuilder.AddColumn<int>(
                name: "weapon",
                table: "characters",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_characters_weapon",
                table: "characters",
                column: "weapon",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_characters_OwnedWeapon_weapon",
                table: "characters",
                column: "weapon",
                principalTable: "OwnedWeapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_OwnedWeapon_weapon",
                table: "characters");

            migrationBuilder.DropIndex(
                name: "IX_characters_weapon",
                table: "characters");

            migrationBuilder.DropColumn(
                name: "weapon",
                table: "characters");

            migrationBuilder.AddColumn<int>(
                name: "characterId",
                table: "OwnedWeapon",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnedWeapon_characterId",
                table: "OwnedWeapon",
                column: "characterId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedWeapon_characters_characterId",
                table: "OwnedWeapon",
                column: "characterId",
                principalTable: "characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
