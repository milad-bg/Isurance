using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class delete_mediaRed_In_mediaentiy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaRef",
                table: "MediaEntities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MediaRef",
                table: "MediaEntities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
