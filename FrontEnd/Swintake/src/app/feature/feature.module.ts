import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';
import { RoutingModule } from '../routing/routing.module';
import { LoginComponent } from './login/login.component';
import { JobApplicationsComponent } from './job-applications/jobapplication-list/job-applications.component';
import { CampaignDetailComponent } from './campaigns/campaign-detail/campaign-detail.component';
import { CampaignCreateComponent } from './campaigns/campaign-create/campaign-create.component';
import { CampaignListComponent } from './campaigns/campaign-list/campaign-list.component';
import { NgbdModalContent } from '../feature/login/login.component';
import { CandidateCreateComponent } from './candidates/candidate-create/candidate-create.component';
import { CandidateListComponent } from './candidates/candidate-list/candidate-list/candidate-list.component';
import { CandidateDetailComponent } from './candidates/candidate-detail/candidate-detail.component';
import { CampaignDropdownComponent } from './job-applications/campaign-dropdown/campaign-dropdown.component';
import { JobapplicationDetailComponent } from './job-applications/jobapplication-detail/jobapplication-detail.component';
import { DetailcandidateComponent } from './job-applications/jobapplication-detail/detailcandidate/detailcandidate.component';
import { DetailcampaignComponent } from './job-applications/jobapplication-detail/detailcampaign/detailcampaign.component';
import { SelectionStepsComponent } from './job-applications/selection-steps/selection-steps.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    LoginComponent, 
    JobApplicationsComponent, 
    CampaignDetailComponent, 
    CampaignCreateComponent, 
    CampaignListComponent, 
    NgbdModalContent, 
    CandidateCreateComponent, 
    CandidateListComponent,
    CandidateDetailComponent,
    CampaignDropdownComponent,
    JobapplicationDetailComponent,
    DetailcandidateComponent,
    DetailcampaignComponent,
    SelectionStepsComponent
  ],
  entryComponents:[NgbdModalContent],
  imports: [
    CommonModule,
    CoreModule,
    RoutingModule,
    SharedModule
  ],
})
export class FeatureModule { }
