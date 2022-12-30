using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addproductservice_in_tender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_Or_Service_Production_Line",
                table: "Tenders");

            migrationBuilder.AddColumn<long>(
                name: "ProductServiceRef",
                table: "Tenders",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ProductServices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    IsFeature = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductServices", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenders_ProductServices_ProductServiceRef",
                table: "Tenders");

            migrationBuilder.DropTable(
                name: "ProductServices");

            migrationBuilder.DropIndex(
                name: "IX_Tenders_ProductServiceRef",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "ProductServiceRef",
                table: "Tenders");

            migrationBuilder.AddColumn<byte>(
                name: "product_Or_Service_Production_Line",
                table: "Tenders",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
