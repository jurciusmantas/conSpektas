using Microsoft.EntityFrameworkCore.Migrations;

namespace conSpektas.Data.Migrations
{
    public partial class conspect_context_remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Conspects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Conspects",
                nullable: false,
                defaultValue: "");
        }
    }
}
