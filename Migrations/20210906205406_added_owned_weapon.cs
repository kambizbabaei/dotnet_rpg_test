using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace pr.Migrations
{
    public partial class added_owned_weapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_Weapon_weaponId",
                table: "characters");

            migrationBuilder.DropTable(
                name: "UserWeapon");

            migrationBuilder.DropIndex(
                name: "IX_characters_weaponId",
                table: "characters");

            migrationBuilder.DropColumn(
                name: "weaponId",
                table: "characters");

            migrationBuilder.CreateTable(
                name: "OwnedWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Health = table.Column<int>(type: "integer", nullable: false),
                    weaponId = table.Column<int>(type: "integer", nullable: true),
                    userId = table.Column<int>(type: "integer", nullable: true),
                    characterId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedWeapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedWeapon_characters_characterId",
                        column: x => x.characterId,
                        principalTable: "characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OwnedWeapon_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OwnedWeapon_Weapon_weaponId",
                        column: x => x.weaponId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnedWeapon_characterId",
                table: "OwnedWeapon",
                column: "characterId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedWeapon_userId",
                table: "OwnedWeapon",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedWeapon_weaponId",
                table: "OwnedWeapon",
                column: "weaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnedWeapon");

            migrationBuilder.AddColumn<int>(
                name: "weaponId",
                table: "characters",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserWeapon",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    WeaponsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWeapon", x => new { x.UserId, x.WeaponsId });
                    table.ForeignKey(
                        name: "FK_UserWeapon_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWeapon_Weapon_WeaponsId",
                        column: x => x.WeaponsId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_characters_weaponId",
                table: "characters",
                column: "weaponId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWeapon_WeaponsId",
                table: "UserWeapon",
                column: "WeaponsId");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_Weapon_weaponId",
                table: "characters",
                column: "weaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
