using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace conSpektas.Data.Migrations
{
    public partial class conspect_context_reborn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Conspects",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Conspects");
        }
    }
}
