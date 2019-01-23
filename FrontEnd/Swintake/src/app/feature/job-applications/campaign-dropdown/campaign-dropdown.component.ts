import { Component, OnInit } from '@angular/core';
import { CampaignService } from 'src/app/core/campaigns/services/campaign.service';
import { Campaign } from 'src/app/core/campaigns/classes/campaign';
import { ActivatedRoute, Router } from '@angular/router';
import { JobApplicationService } from 'src/app/core/jobapplications/services/jobapplication.service';

@Component({
  selector: 'app-campaign-dropdown',
  templateUrl: './campaign-dropdown.component.html',
  styleUrls: ['./campaign-dropdown.component.css']
})
export class CampaignDropdownComponent implements OnInit {

  campaings: Campaign[];
  selectedCampaign: string;
  candidateId: string;

  constructor(private campaignService: CampaignService, private route: ActivatedRoute, private jobApplicationService: JobApplicationService, private _router: Router) 
  { 
    this.campaignService.getCampaigns().subscribe(data => this.campaings = data,
      error => console.log(error));
      this.route.params.subscribe(params => { 
        this.candidateId = params['id'];
      });

  }

  ngOnInit() {
  }

  onSubmit(){
    this.jobApplicationService.createJobApplication(this.selectedCampaign, this.candidateId)
    .subscribe(data => {this._router.navigateByUrl('/jobapplications')});
  }  

  cancel(){
    this._router.navigateByUrl(`/candidates/${this.candidateId}`);
  }
}
