namespace Domain.Domain.Entities.Tendor
{
    public class Tender : BaseEntity
    {
        public string NameCompanyApplicant { get; set; }

        public string RegistrationNumber { get; set; }

        public int NationalCode { get; set; }

        public int NationalID { get; set; }

        public string EconomicCode { get; set; }

        public string CooperationRequestLetterNumber { get; set; }

        public bool AllowOrganization { get; set; }

        public string AddressWebSite { get; set; }

        public string AddressCompany { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstLastNameCTO { get; set; }

        public string FactoryName { get; set; }

        public string FactoryAddress { get; set; }

        public bool IsKnowledgeBase { get; set; }
    }
}
