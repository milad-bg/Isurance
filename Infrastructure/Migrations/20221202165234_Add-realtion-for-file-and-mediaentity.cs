using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Addrealtionforfileandmediaentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaEntities_Files_MediaId",
                table: "MediaEntities");

            migrationBuilder.DropIndex(
                name: "IX_MediaEntities_MediaId",
                table: "MediaEntities");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "MediaEntities");

            migrationBuilder.AddColumn<long>(
                name: "MediaRef",
                table: "MediaEntities",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_MediaEntities_MediaRef",
                table: "MediaEntities",
                column: "MediaRef");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaEntities_Files_MediaRef",
                table: "MediaEntities",
                column: "MediaRef",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaEntities_Files_MediaRef",
                table: "MediaEntities");

            migrationBuilder.DropIndex(
                name: "IX_MediaEntities_MediaRef",
                table: "MediaEntities");

            migrationBuilder.DropColumn(
                name: "MediaRef",
                table: "MediaEntities");

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "MediaEntities",
                type: "bigint",
                nullable: true);

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
    }
}
