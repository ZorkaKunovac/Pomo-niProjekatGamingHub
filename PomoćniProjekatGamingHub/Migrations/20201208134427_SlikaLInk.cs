using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomoćniProjekatGamingHub.Migrations
{
    public partial class SlikaLInk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "SlikaLink",
                table: "Igra",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlikaLink",
                table: "Igra");
        }
    }
}
