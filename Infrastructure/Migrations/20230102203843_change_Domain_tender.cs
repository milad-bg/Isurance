using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class change_Domain_tender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenders_ProductServices_ProductServiceRef",
                table: "Tenders");

            migrationBuilder.DropIndex(
                name: "IX_Tenders_ProductServiceRef",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "ProductServiceRef",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Keyword",
                table: "Files");

            migrationBuilder.AddColumn<byte>(
                name: "ProductService",
                table: "Tenders",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "ProductServiceId",
                table: "Tenders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_ProductServiceId",
                table: "Tenders",
                column: "ProductServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenders_ProductServices_ProductServiceId",
                table: "Tenders",
                column: "ProductServiceId",
                principalTable: "ProductServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenders_ProductServices_ProductServiceId",
                table: "Tenders");

            migrationBuilder.DropIndex(
                name: "IX_Tenders_ProductServiceId",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "ProductService",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "ProductServiceId",
                table: "Tenders");

            migrationBuilder.AddColumn<long>(
                name: "ProductServiceRef",
                table: "Tenders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Keyword",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_ProductServiceRef",
                table: "Tenders",
                column: "ProductServiceRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenders_ProductServices_ProductServiceRef",
                table: "Tenders",
                column: "ProductServiceRef",
                principalTable: "ProductServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
