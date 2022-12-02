using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Add_Domain_File : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keyword",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MediaEntity",
                table: "Files",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "Files",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Files",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Keyword",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "MediaEntity",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Files");
        }
    }
}
