import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ApiUrl } from '../../CommonUrl/CommonUrl';
import { JobApplication } from '../classes/jobApplication';
import { Observable } from 'rxjs';
import { JobapplicationDetailComponent } from 'src/app/feature/job-applications/jobapplication-detail/jobapplication-detail.component';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()

export class JobApplicationService {

  constructor(private http: HttpClient) { }

  createJobApplication(campaignId: string, candidateId: string): Observable<JobApplication> {
    return this.http.post<JobApplication>(ApiUrl.urlJobApplications, { candidateId, campaignId }, httpOptions);
  }
 
  getJobApplicationById(id: string): Observable<JobApplication> {
    return this.http.get<JobApplication>(`${ApiUrl.urlJobApplications}${id}`);
  }

  getJobApplications(): Observable<JobApplication[]>{
    return this.http.get<JobApplication[]>(ApiUrl.urlJobApplications);
  }

  rejectJobApplication(id: string): Observable<JobApplication>{
    return this.http.put<JobApplication>(`${ApiUrl.urlJobApplications}reject/${id}`, {}, httpOptions);
  }

  acceptCandidate(id: string): Observable<JobApplication>{
    return this.http.put<JobApplication>(`${ApiUrl.urlJobApplications}accept/${id}`, {}, httpOptions);
  }


 saveNextSelectionStep(id: string, comment: string): Observable<JobApplication> {
    return this.http.put<JobApplication>(`${ApiUrl.urlJobApplications}nextstep/${id}`, JSON.stringify(comment) , httpOptions)
  }

}
