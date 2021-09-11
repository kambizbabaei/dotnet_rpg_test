using Microsoft.EntityFrameworkCore.Migrations;

namespace pr.Migrations
{
    public partial class added_power_to_weapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "power",
                table: "Weapon",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "power",
                table: "Weapon");
        }
    }
}
