import { Component, OnInit } from '@angular/core';
import { CampaignService } from '../../../core/campaigns/services/campaign.service';
import { Campaign } from '../../../core/campaigns/classes/campaign';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-campaign-detail',
  templateUrl: './campaign-detail.component.html',
  styleUrls: ['./campaign-detail.component.css']
})
export class CampaignDetailComponent implements OnInit {
  campaign: Campaign;
  constructor(private campaignService: CampaignService,  private route: ActivatedRoute) { }


  ngOnInit() {
    this.getCampaign()
  }

  getCampaign(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.campaignService.getCampaignById(id)
    .subscribe(campaign => this.campaign = campaign);
  }

}
