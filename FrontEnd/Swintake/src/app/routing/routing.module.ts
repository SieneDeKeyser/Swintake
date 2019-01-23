import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router'
import { LoginComponent } from '../feature/login/login.component';
import { JobApplicationsComponent } from '../feature/job-applications/jobapplication-list/job-applications.component';
import { CampaignCreateComponent } from '../feature/campaigns/campaign-create/campaign-create.component';
import { CampaignListComponent } from '../feature/campaigns/campaign-list/campaign-list.component';
import { AuthGuard } from '../core/authentication/helpers/auth.guard';
import { CandidateDetailComponent } from '../feature/candidates/candidate-detail/candidate-detail.component';
import { CandidateCreateComponent } from '../feature/candidates/candidate-create/candidate-create.component';
import { CandidateListComponent } from '../feature/candidates/candidate-list/candidate-list/candidate-list.component';
import { JobapplicationDetailComponent } from '../feature/job-applications/jobapplication-detail/jobapplication-detail.component';
import { CampaignDetailComponent } from '../feature/campaigns/campaign-detail/campaign-detail.component';


const routes: Routes=[
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'campaigns', component: CampaignListComponent, canActivate: [AuthGuard]},
  {path: 'jobapplications', component: JobApplicationsComponent, canActivate: [AuthGuard]},
  {path: 'createcampaign', component: CampaignCreateComponent, canActivate: [AuthGuard]},
  {path: 'candidates/:id', component: CandidateDetailComponent, canActivate: [AuthGuard] },
  {path: 'createcandidate', component: CandidateCreateComponent, canActivate:[AuthGuard]},
  {path: 'candidates', component: CandidateListComponent, canActivate:[AuthGuard]},
  {path: 'campaigns/:id', component: CampaignDetailComponent, canActivate:[AuthGuard]},
  {path: 'jobapplications/:id', component: JobapplicationDetailComponent, canActivate:[AuthGuard]}

];

@NgModule({
  exports: 
  [
    RouterModule
  ],
  imports: 
  [
    RouterModule.forRoot(routes)
  ]
})
export class RoutingModule { }
