using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Chnge_domain_newscast_for_prority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsPriority",
                table: "NewsCasts");

            migrationBuilder.AddColumn<long>(
                name: "Priority",
                table: "NewsCasts",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "NewsCasts");

            migrationBuilder.AddColumn<byte>(
                name: "NewsPriority",
                table: "NewsCasts",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
