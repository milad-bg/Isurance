using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Add_titie_In_Aboutus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aboutus",
                table: "AboutUs");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AboutUs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "AboutUs");

            migrationBuilder.AddColumn<string>(
                name: "Aboutus",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
