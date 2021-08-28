using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace pr.Migrations
{
    public partial class addedListMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceResponse<List<Character>>Id",
                table: "characters",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "serviceListMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isSuccessful = table.Column<bool>(type: "boolean", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceListMessage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_characters_ServiceResponse<List<Character>>Id",
                table: "characters",
                column: "ServiceResponse<List<Character>>Id");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_serviceListMessage_ServiceResponse<List<Characte~",
                table: "characters",
                column: "ServiceResponse<List<Character>>Id",
                principalTable: "serviceListMessage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_serviceListMessage_ServiceResponse<List<Characte~",
                table: "characters");

            migrationBuilder.DropTable(
                name: "serviceListMessage");

            migrationBuilder.DropIndex(
                name: "IX_characters_ServiceResponse<List<Character>>Id",
                table: "characters");

            migrationBuilder.DropColumn(
                name: "ServiceResponse<List<Character>>Id",
                table: "characters");
        }
    }
}
