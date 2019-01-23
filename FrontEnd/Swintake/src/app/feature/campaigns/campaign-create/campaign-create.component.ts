import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Campaign } from 'src/app/core/campaigns/classes/campaign';
import { CampaignService } from '../../../core/campaigns/services/campaign.service';

@Component({
  selector: 'app-campaign-create',
  templateUrl: './campaign-create.component.html',
  styleUrls: ['./campaign-create.component.css']
})
export class CampaignCreateComponent implements OnInit {

    campaign: Campaign = new Campaign();
    submitted = false;
    createNewCampaignForm:FormGroup;
    errorMessageForClassStartDate: string;

  constructor(
    private campaignService: CampaignService,
    private formbuilder: FormBuilder,
    private _router: Router) { }

    ngOnInit() {
      this.campaign.name="new Campaign";
      this.createNewCampaignForm = this.formbuilder.group({
        name: ['', Validators.required],
        client: ['', Validators.required],
        startDate: ['', Validators.required],
        classStartDate: ['', Validators.required],
        comment: ['']
      });
      
  }

  create() {
          this.campaignService.addCampaign(this.createNewCampaignForm.value)
              .subscribe(data => {
                this._router.navigateByUrl('/campaigns'),
                error => console.log(error);
              });
  }

  cancel(){
    this._router.navigateByUrl('/campaigns');  }

  get formValues(){
    return this.createNewCampaignForm.controls;
  }

  isValid(): boolean{
    this.submitted=true;
    this.errorMessageForClassStartDate = this.compareTwoDates();
    if(this.createNewCampaignForm.invalid || this.errorMessageForClassStartDate != null)
    {
      return false;
    }
   return true;
  }

  compareTwoDates(){
    let dateStartClassCampaign = new Date(this.formValues.classStartDate.value).toISOString().slice(0,10);
    let dateStartCampaign = new Date(this.formValues.startDate.value).toISOString().slice(0,10);
    if(dateStartClassCampaign <  dateStartCampaign){
      return `The class startDate can't start before the campaing start date`;
    }
    return null;
  }

}