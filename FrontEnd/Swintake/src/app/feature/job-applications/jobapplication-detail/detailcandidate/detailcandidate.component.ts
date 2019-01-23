import { Component, OnInit, Input } from '@angular/core';
import { Candidate } from 'src/app/core/candidates/classes/candidate';
import { CandidateService } from 'src/app/core/candidates/services/candidate.service';
import { ActivatedRoute } from '@angular/router';
import { JobApplication } from 'src/app/core/jobapplications/classes/jobApplication';
import { JobApplicationService } from 'src/app/core/jobapplications/services/jobapplication.service';

@Component({
  selector: 'app-detailcandidate',
  templateUrl: './detailcandidate.component.html',
  styleUrls: ['./detailcandidate.component.css']
})

export class DetailcandidateComponent implements OnInit {

  candidateId: string;
  //candidate: Candidate = new Candidate();
  @Input() jobapplication: JobApplication ;

  constructor(
    private candidateService: CandidateService,
    private route: ActivatedRoute,
    private jobAppService: JobApplicationService) { }

  ngOnInit() {
    //this.candidate = this.jobApplication.candidate;
    //this.getJobApplication();
  }

  // getJobApplication(): any {
  //   const id = this.route.snapshot.paramMap.get('id');
  //   this.jobAppService.getJobApplicationById(id)
  //     .subscribe(jobapp => { 
  //       this.jobapp = jobapp;
  //       this.candidateService.getCandidateById(jobapp.candidateId)
  //         .subscribe(candidate => this.candidate = candidate)
  //     });
  // }
  
}