using Domain.Enums.Flies;
using Microsoft.AspNetCore.Http;

namespace Application.Servises.Files.Commads
{
    public class FileUploadCommand
    {
        public string Keword { get; set; }

        public MediaType MediaType { get; set; }
    }
}
