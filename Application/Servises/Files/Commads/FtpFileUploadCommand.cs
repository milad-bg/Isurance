using Domain.Enums.Flies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Servises.Files.Commads
{
    public class FtpFileUploadCommand
    {
        public string FileName { get; set; }
        public MediaEntityType MediaType{ get; set; }
    }
}
