import { Component, OnInit } from '@angular/core';
import { JobApplication } from 'src/app/core/jobapplications/classes/jobApplication';
import { JobApplicationService } from 'src/app/core/jobapplications/services/jobapplication.service';

@Component({
  selector: 'app-job-applications',
  templateUrl: './job-applications.component.html',
  styleUrls: ['./job-applications.component.css']
})
export class JobApplicationsComponent implements OnInit {

  jobApplications: JobApplication[] = [];
  constructor(private jobApplicationService: JobApplicationService) { }

  ngOnInit() {
    this.getAllJobApplications();
  }

  getAllJobApplications(): void {
    this.jobApplicationService.getJobApplications()
      .subscribe(jobApplications => this.jobApplications = jobApplications);
  }
}
