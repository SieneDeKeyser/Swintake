using Swintake.domain.JobApplications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.FilesToUpload
{
    public enum FileType
    {
        Cv,
        MotivationLetter
    }

   public class FileToUpload: Entity
    {
        public FileToUpload()
        {
        }

        public FileToUpload(Guid id) : base(id)
        {
        }

        public FileType Filetype { get; set; }
        public string FileName { get; set; }
        public string FileContent { get; set; }
        public byte [] UploadedFileContent { get; set; }
        public Guid JobApplicationId { get; set; }
    }
}
