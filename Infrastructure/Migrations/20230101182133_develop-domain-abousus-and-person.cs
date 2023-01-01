using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class developdomainaboususandperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "AboutUs");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Persons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Persons");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "AboutUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "AboutUs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
