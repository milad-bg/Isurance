using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Add_Domain_AboutUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AboutUsId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aboutus",
                table: "AboutUs",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Aboutus",
                table: "AboutUs");
        }
    }
}
