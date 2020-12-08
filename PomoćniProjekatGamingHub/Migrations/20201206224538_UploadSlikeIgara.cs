using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomoćniProjekatGamingHub.Migrations
{
    public partial class UploadSlikeIgara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "SlikaLink",
                table: "Igra",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SlikaLink",
                table: "Igra",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
