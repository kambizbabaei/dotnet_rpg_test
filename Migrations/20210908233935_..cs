using Microsoft.EntityFrameworkCore.Migrations;

namespace pr.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_OwnedWeapon_weapon",
                table: "characters");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedWeapon_Users_userId",
                table: "OwnedWeapon");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedWeapon_Weapon_weaponId",
                table: "OwnedWeapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnedWeapon",
                table: "OwnedWeapon");

            migrationBuilder.RenameTable(
                name: "Weapon",
                newName: "Weapons");

            migrationBuilder.RenameTable(
                name: "OwnedWeapon",
                newName: "UserWeapons");

            migrationBuilder.RenameIndex(
                name: "IX_OwnedWeapon_weaponId",
                table: "UserWeapons",
                newName: "IX_UserWeapons_weaponId");

            migrationBuilder.RenameIndex(
                name: "IX_OwnedWeapon_userId",
                table: "UserWeapons",
                newName: "IX_UserWeapons_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWeapons",
                table: "UserWeapons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_UserWeapons_weapon",
                table: "characters",
                column: "weapon",
                principalTable: "UserWeapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWeapons_Users_userId",
                table: "UserWeapons",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWeapons_Weapons_weaponId",
                table: "UserWeapons",
                column: "weaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_UserWeapons_weapon",
                table: "characters");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWeapons_Users_userId",
                table: "UserWeapons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWeapons_Weapons_weaponId",
                table: "UserWeapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWeapons",
                table: "UserWeapons");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "Weapon");

            migrationBuilder.RenameTable(
                name: "UserWeapons",
                newName: "OwnedWeapon");

            migrationBuilder.RenameIndex(
                name: "IX_UserWeapons_weaponId",
                table: "OwnedWeapon",
                newName: "IX_OwnedWeapon_weaponId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWeapons_userId",
                table: "OwnedWeapon",
                newName: "IX_OwnedWeapon_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnedWeapon",
                table: "OwnedWeapon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_OwnedWeapon_weapon",
                table: "characters",
                column: "weapon",
                principalTable: "OwnedWeapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedWeapon_Users_userId",
                table: "OwnedWeapon",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedWeapon_Weapon_weaponId",
                table: "OwnedWeapon",
                column: "weaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
