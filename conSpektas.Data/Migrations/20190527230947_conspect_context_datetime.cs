using Microsoft.EntityFrameworkCore.Migrations;

namespace conSpektas.Data.Migrations
{
    public partial class conspect_context_datetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LatestEditDate",
                table: "Conspects",
                newName: "Inserted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Inserted",
                table: "Conspects",
                newName: "LatestEditDate");
        }
    }
}
