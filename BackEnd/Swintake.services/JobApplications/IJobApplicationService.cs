﻿using Swintake.domain.FilesToUpload;
using Swintake.domain.JobApplications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.services.JobApplications
{
    public interface IJobApplicationService
    {
        JobApplication AddJobApplication(JobApplication jobApplication);
        JobApplication GetJobApplicationById(string id);
        JobApplication RejectJobApplication(string jobApplicationIdToReject);
        JobApplication AcceptJobApplication(string id);
        IEnumerable<JobApplication> GetJobApplications();
        JobApplication GoToNextSelectionStepInSelectionProcess(string id, string comment);
        JobApplication UploadFileToJobApplication(JobApplication jobApp, FileToUpload file);

        JobApplication EditComment(string id, string descriptionSelectionStep, string comment);
    }
}
