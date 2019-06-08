using Microsoft.EntityFrameworkCore.Migrations;

namespace conSpektas.Data.Migrations
{
    public partial class Ratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ConspectsRatings");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "CommentsRatings");

            migrationBuilder.AddColumn<bool>(
                name: "Positive",
                table: "ConspectsRatings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Conspects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Positive",
                table: "CommentsRatings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Positive",
                table: "ConspectsRatings");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Conspects");

            migrationBuilder.DropColumn(
                name: "Positive",
                table: "CommentsRatings");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "ConspectsRatings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "CommentsRatings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
