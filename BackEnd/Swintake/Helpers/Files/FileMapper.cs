using Microsoft.AspNetCore.Http;
using Swintake.domain.FilesToUpload;
using Swintake.infrastructure.Exceptions;
using Swintake.infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.Files
{
    public class FileMapper
    {
        public FileDtoWithFormFile ToFileDtoWithFormFile(FileDTOToCreate filedto, IFormFile formfile)
        {
            return new FileDtoWithFormFile()
            {
                jobApplicationId = filedto.JobApplicationId,
                FileType = filedto.FileType,
                FileToUpload = formfile
            };
        }

        public FileToUpload ToDomainFile(FileDtoWithFormFile filedto)
        {
            var newFile = new FileToUpload(Guid.NewGuid());
            switch (filedto.FileType)
            {
                case "CV":
                    newFile.Filetype = FileType.Cv;
                    break;
                case "MotivationLetter":

                    newFile.Filetype = FileType.MotivationLetter;
                    break;
                default:
                    throw new EntityNotValidException("Type of file does not exist", filedto);
            }


            newFile.FileName = filedto.FileToUpload.FileName;
            newFile.FileContent = filedto.FileToUpload.ContentType;

            using (var memorystream = new MemoryStream())
            {
                filedto.FileToUpload.CopyTo(memorystream);
                newFile.UploadedFileContent = memorystream.ToArray();
            }

            return newFile;
        }
    }
}
