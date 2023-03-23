using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _7agz.EF.Migrations
{
    public partial class ConvertPositionToNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayersData_PlayerId",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "PlayerPosition",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayersData_PlayerId",
                table: "PlayersData",
                column: "PlayerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayersData_PlayerId",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "PlayerPosition",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersData_PlayerId",
                table: "PlayersData",
                column: "PlayerId");
        }
    }
}
