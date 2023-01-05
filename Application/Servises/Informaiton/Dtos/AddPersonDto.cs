namespace Application.Servises.Informaiton.Dtos
{
    public class AddPersonDto
    {
        public string FullName { get; set; }

        public string GroupName { get; set; }

        public string JobTitle { get; set; }

        public string CoverMediaUrl { get; set; }

        public long CoverMediaId { get; set; }

        public int Priority { get; set; }

    }
}
