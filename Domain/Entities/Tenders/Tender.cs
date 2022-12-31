using Domain.Entities.Tenders;
using Domain.Enums.Tenders;

namespace Domain.Domain.Entities.Tendor
{
    public class Tender : BaseEntity
    {
        public string Name_Of_The_Applicant_Ccompany { get; set; }

        public string Registration_Number { get; set; }
            
        public int National_Code { get; set; }

        public int National_ID { get; set; }

        public string Economic_Code { get; set; }

        public ProductService ProductService { get; set; }
        public long ProductServiceRef { get; set; }

        public string Cooperation_Request_Letter_Number { get; set; }

        public bool Have_You_Been_An_Authorized_Supplier_Of_The_Social_Security_Organization_Before { get; set; }

        public string Address_WebSite { get; set; }

        public string Address_Company { get; set; }

        public string Phone_Number { get; set; }

        public string Name_And_Surname_Of_The_CEO { get; set; }

        public string Factory_Name { get; set; }

        public string Factory_Address { get; set; }

        public bool Are_You_A_Knowledge_Based_Company { get; set; }

        public string Flagship_Project_Of_The_Social_Security_Organization { get; set; }

        public string The_Therapeutic_Index_Project_That_Provides_Goods_OrIimplements { get; set; }

        public string Which_Government_Collections_Are_You_An_Aauthorized_Supplier_Of { get; set; }

        public bool Do_You_Have_An_Introduction_Letter_Or_ALetter_Of_Aappreciation_Within_The_Social_Security_Organization { get; set; }

        public string Letter_Of_Introduction_And_Appreciation { get; set; }

        public string Aadopted_Standards { get; set; } 

        public string Licenses_Etc { get; set; }

        public bool Representation_Of_Foreign_Brands { get; set; }

        public string Experience { get; set; }

        public string Email_For_Essential_Correspondence { get; set; }
    }
}
