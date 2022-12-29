using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Refactor_Mode_NewsCast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "NewsCasts");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "NewsCasts",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFeaturedPriority",
                table: "NewsCasts",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<string>(
                name: "DownContent",
                table: "NewsCasts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeaturedPriority",
                table: "NewsCasts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpperContent",
                table: "NewsCasts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownContent",
                table: "NewsCasts");

            migrationBuilder.DropColumn(
                name: "FeaturedPriority",
                table: "NewsCasts");

            migrationBuilder.DropColumn(
                name: "UpperContent",
                table: "NewsCasts");

            migrationBuilder.AlterColumn<long>(
                name: "Priority",
                table: "NewsCasts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<byte>(
                name: "IsFeaturedPriority",
                table: "NewsCasts",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "NewsCasts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
