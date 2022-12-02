using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Delete_title_in_domain_file : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Files");

            migrationBuilder.AddColumn<long>(
                name: "EntityRef",
                table: "MediaEntities",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "EntityType",
                table: "MediaEntities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "MediaEntityType",
                table: "MediaEntities",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "MediaEntities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MediaRef",
                table: "MediaEntities",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_MediaEntities_MediaId",
                table: "MediaEntities",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaEntities_Files_MediaId",
                table: "MediaEntities",
                column: "MediaId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaEntities_Files_MediaId",
                table: "MediaEntities");

            migrationBuilder.DropIndex(
                name: "IX_MediaEntities_MediaId",
                table: "MediaEntities");

            migrationBuilder.DropColumn(
                name: "EntityRef",
                table: "MediaEntities");

            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "MediaEntities");

            migrationBuilder.DropColumn(
                name: "MediaEntityType",
                table: "MediaEntities");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "MediaEntities");

            migrationBuilder.DropColumn(
                name: "MediaRef",
                table: "MediaEntities");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
