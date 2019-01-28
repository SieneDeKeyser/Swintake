using Swintake.domain.FilesToUpload;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swintake.services.Files
{
    public interface IFileService
    {
        Task<FileToUpload> UploadFile(FileToUpload fileToUpload, string jobApplicationId);
    }
}
