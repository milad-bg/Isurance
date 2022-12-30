using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class fix_relation_aboutus_person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_AboutUs_AboutUsId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_AboutUsId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AboutUsId",
                table: "Persons");

            migrationBuilder.AddColumn<long>(
                name: "AboutUsRef",
                table: "Persons",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AboutUsRef",
                table: "Persons",
                column: "AboutUsRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_AboutUs_AboutUsRef",
                table: "Persons",
                column: "AboutUsRef",
                principalTable: "AboutUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_AboutUs_AboutUsRef",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_AboutUsRef",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AboutUsRef",
                table: "Persons");

            migrationBuilder.AddColumn<long>(
                name: "AboutUsId",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AboutUsId",
                table: "Persons",
                column: "AboutUsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_AboutUs_AboutUsId",
                table: "Persons",
                column: "AboutUsId",
                principalTable: "AboutUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
