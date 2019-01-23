import { Component, OnInit, Input } from '@angular/core';
import { Campaign } from 'src/app/core/campaigns/classes/campaign';
import { CampaignService } from 'src/app/core/campaigns/services/campaign.service';
import { ActivatedRoute } from '@angular/router';
import { JobApplication } from 'src/app/core/jobapplications/classes/jobApplication';
import { JobApplicationService } from 'src/app/core/jobapplications/services/jobapplication.service';

@Component({
  selector: 'app-detailcampaign',
  templateUrl: './detailcampaign.component.html',
  styleUrls: ['./detailcampaign.component.css']
})
export class DetailcampaignComponent implements OnInit {

  campaignId: string;
 // campaign: Campaign = new Campaign();
  @Input() jobapplication: JobApplication ;
  //jobapp: JobApplication = new JobApplication();

  constructor(
    private campaignService: CampaignService,
    private route: ActivatedRoute,
    private jobAppService: JobApplicationService) { }

  ngOnInit() {
   // this.campaign= this.jobApplication.campaign;
    //this.getJobApplication();
  }

  // getJobApplication(): any {
  //   const id = this.route.snapshot.paramMap.get('id');
  //   this.jobAppService.getJobApplicationById(id)
  //     .subscribe(jobapp => { 
  //       this.jobapp = jobapp;
  //       this.campaignService.getCampaignById(jobapp.campaignId)
  //         .subscribe(campaign => this.campaign = campaign)
  //     });
  // }
  
}