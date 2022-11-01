using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addPropertyNewsCast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "NewsCasts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "NewsCasts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "NewsCasts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "IsFeaturedPriority",
                table: "NewsCasts",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "NewsPriority",
                table: "NewsCasts",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "NewsCasts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "NewsCasts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "NewsCasts");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "NewsCasts");

            migrationBuilder.DropColumn(
                name: "IsFeaturedPriority",
                table: "NewsCasts");

            migrationBuilder.DropColumn(
                name: "NewsPriority",
                table: "NewsCasts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "NewsCasts");
        }
    }
}
