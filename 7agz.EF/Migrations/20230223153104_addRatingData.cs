using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _7agz.EF.Migrations
{
    public partial class addRatingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Draw",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "Lose",
                table: "PlayersData");

            migrationBuilder.RenameColumn(
                name: "Wins",
                table: "PlayersData",
                newName: "player_possition");

            migrationBuilder.AddColumn<bool>(
                name: "ReserverType",
                table: "ReservedHours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rank",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "defending",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "dribbling",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "gk_diving",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "gk_handling",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "gk_kicking",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "gk_positioning",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "gk_reflexes",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "gk_speed",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "pace",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "passing",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "shooting",
                table: "PlayersData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReserverType",
                table: "ReservedHours");

            migrationBuilder.DropColumn(
                name: "defending",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "dribbling",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "gk_diving",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "gk_handling",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "gk_kicking",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "gk_positioning",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "gk_reflexes",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "gk_speed",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "pace",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "passing",
                table: "PlayersData");

            migrationBuilder.DropColumn(
                name: "shooting",
                table: "PlayersData");

            migrationBuilder.RenameColumn(
                name: "player_possition",
                table: "PlayersData",
                newName: "Wins");

            migrationBuilder.AlterColumn<int>(
                name: "Rank",
                table: "PlayersData",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "Draw",
                table: "PlayersData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lose",
                table: "PlayersData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
