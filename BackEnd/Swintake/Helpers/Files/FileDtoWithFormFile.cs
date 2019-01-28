using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.Files
{
    public class FileDtoWithFormFile
    {
        public string jobApplicationId { get; set; }
        public string FileType { get; set; }
        public IFormFile FileToUpload { get; set; }
    }
}
