import { Component, OnInit } from '@angular/core';
import { Campaign } from '../../../core/campaigns/classes/campaign';
import { CampaignService } from '../../../core/campaigns/services/campaign.service';

@Component({
  selector: 'app-campaign-list',
  templateUrl: './campaign-list.component.html',
  styleUrls: ['./campaign-list.component.css']
})
export class CampaignListComponent implements OnInit {

  campaigns: Campaign[] = [];
  allCampaigns: Campaign[] = [];

  constructor(private campaignService: CampaignService) { }

  ngOnInit() {
    this.getAllCampaigns();
  }

  getAllCampaigns(): void {
    this.campaignService.getCampaigns()
      .subscribe(campaigns => {
       this.campaigns = campaigns
       this.allCampaigns = campaigns
      });
  }

  
  seachByTitle(givenSearchTerm: string) {
    this.campaigns = this.campaignService.searchItem(givenSearchTerm,this.allCampaigns);
  } 

}
