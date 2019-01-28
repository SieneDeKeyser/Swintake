using Swintake.domain.FilesToUpload;
using Swintake.services.JobApplications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swintake.services.Files
{
    public class FileService: IFileService
    {
        private readonly FileRepository _fileRepository;
        private readonly IJobApplicationService _jobApplicationService;

        public FileService(FileRepository fileRepository, IJobApplicationService jobApplicationService)
        {
            _fileRepository = fileRepository;
            _jobApplicationService = jobApplicationService;
        }

        public async Task<FileToUpload> UploadFile(FileToUpload fileToUpload, string jobApplicationId)
        {
            var jobApplication = _jobApplicationService.GetJobApplicationById(jobApplicationId);
            fileToUpload.JobApplicationId = jobApplication.Id;
            var uploadedFile = await _fileRepository.UploadFile(fileToUpload);
            _jobApplicationService.UploadFileToJobApplication(jobApplication, uploadedFile);
            return uploadedFile;
        }
    }
}
