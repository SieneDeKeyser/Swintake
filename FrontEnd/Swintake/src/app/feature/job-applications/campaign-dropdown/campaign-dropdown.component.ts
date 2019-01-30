import { Component, OnInit, ViewChild } from '@angular/core';
import { CampaignService } from 'src/app/core/campaigns/services/campaign.service';
import { Campaign } from 'src/app/core/campaigns/classes/campaign';
import { ActivatedRoute, Router, ChildActivationEnd } from '@angular/router';
import { JobApplicationService } from 'src/app/core/jobapplications/services/jobapplication.service';
import { UploadFilesComponent } from '../../upload-files/upload-files.component';
import { FileService } from 'src/app/core/files/services/file.service';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-campaign-dropdown',
  templateUrl: './campaign-dropdown.component.html',
  styleUrls: ['./campaign-dropdown.component.css']
})
export class CampaignDropdownComponent implements OnInit {

  campaings: Campaign[];
  selectedCampaign: string;
  candidateId: string;

  @ViewChild(UploadFilesComponent) child;

  constructor(private campaignService: CampaignService, 
              private route: ActivatedRoute, 
              private jobApplicationService: JobApplicationService, 
              private _router: Router,
              private fileService: FileService) 
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
    .pipe(
      finalize(()=> { this._router.navigateByUrl('/jobapplications');})
    )
    .subscribe(data => {
      if(this.child.cvFile){
        this.child.cvFile.jobApplicationId = data.id;
        this.fileService.uploadFile(this.child.cvFile, this.child.formDataCV).subscribe(dataCV=> {
          console.log(dataCV);
        })  
      }
      if(this.child.motivationFile){
        this.child.motivationFile.jobApplicationId = data.id;
        this.fileService.uploadFile(this.child.motivationFile, this.child.formDataMotivation).subscribe(dataMotivation=> {
          console.log(dataMotivation);
        })  
      }
    
    });
  }  

  cancel(){
    this.child.cvFile = null;
    this.child.motivationFile = null;
    this._router.navigateByUrl(`/candidates/${this.candidateId}`);
  }
}
