using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class add_domain_tender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aadopted_Standards",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Company",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_WebSite",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Are_You_A_Knowledge_Based_Company",
                table: "Tenders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Cooperation_Request_Letter_Number",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Do_You_Have_An_Introduction_Letter_Or_ALetter_Of_Aappreciation_Within_The_Social_Security_Organization",
                table: "Tenders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Economic_Code",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email_For_Essential_Correspondence",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Factory_Address",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Factory_Name",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Flagship_Project_Of_The_Social_Security_Organization",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Have_You_Been_An_Authorized_Supplier_Of_The_Social_Security_Organization_Before",
                table: "Tenders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Letter_Of_Introduction_And_Appreciation",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Licenses_Etc",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_And_Surname_Of_The_CEO",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Of_The_Applicant_Ccompany",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "National_Code",
                table: "Tenders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "National_ID",
                table: "Tenders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Registration_Number",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Representation_Of_Foreign_Brands",
                table: "Tenders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "The_Therapeutic_Index_Project_That_Provides_Goods_OrIimplements",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Which_Government_Collections_Are_You_An_Aauthorized_Supplier_Of",
                table: "Tenders",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "product_Or_Service_Production_Line",
                table: "Tenders",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aadopted_Standards",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Address_Company",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Address_WebSite",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Are_You_A_Knowledge_Based_Company",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Cooperation_Request_Letter_Number",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Do_You_Have_An_Introduction_Letter_Or_ALetter_Of_Aappreciation_Within_The_Social_Security_Organization",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Economic_Code",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Email_For_Essential_Correspondence",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Factory_Address",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Factory_Name",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Flagship_Project_Of_The_Social_Security_Organization",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Have_You_Been_An_Authorized_Supplier_Of_The_Social_Security_Organization_Before",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Letter_Of_Introduction_And_Appreciation",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Licenses_Etc",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Name_And_Surname_Of_The_CEO",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Name_Of_The_Applicant_Ccompany",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "National_Code",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "National_ID",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Phone_Number",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Registration_Number",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Representation_Of_Foreign_Brands",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "The_Therapeutic_Index_Project_That_Provides_Goods_OrIimplements",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "Which_Government_Collections_Are_You_An_Aauthorized_Supplier_Of",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "product_Or_Service_Production_Line",
                table: "Tenders");
        }
    }
}
