namespace Domain.Domain.Entities.Information
{
    public class Person : BaseEntity
    {
        public virtual AboutUs AboutUs { get; set; }
        public long AboutUsRef { get; set; }

        public string FullName { get; set; }

        public string GroupName { get; set; }

        public string JobTitle { get; set; }
    }
}
