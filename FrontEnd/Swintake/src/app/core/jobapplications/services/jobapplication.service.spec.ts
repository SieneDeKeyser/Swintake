import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { ApiUrl } from '../../CommonUrl/CommonUrl';
import { JobApplication } from '../classes/jobApplication';
import { JobApplicationService } from './jobapplication.service';
import { Candidate } from '../../candidates/classes/candidate';
import { Campaign } from '../../campaigns/classes/campaign';
import { resource } from 'selenium-webdriver/http';
import { JobapplicationDetailComponent } from 'src/app/feature/job-applications/jobapplication-detail/jobapplication-detail.component';

  describe('JobApplicationService', () => {
  let httpClient: HttpClient;
  let jobApplicationService: JobApplicationService;

  beforeEach(() => {
    httpClient = ({ get: null, post: null } as unknown) as HttpClient;
    jobApplicationService = new JobApplicationService(httpClient);
  });

  fit('should return new JobApplication', () => {

    let candidate: Candidate = {
      firstName: 'Peter',
      lastName: 'Parker',
      email: 'totallynotspiderman@gmail.com',
      phoneNumber: '0470000000',
      gitHubUserName: 'noYOUarespiderman',
      linkedIn: 'pp',
      comment: 'great candidate'
    };

    let campaign: Campaign = {
      name: 'User',
      client: 'Client',
      startDate: new Date(),
      classStartDate: new Date()
    };


    let jobApplication: JobApplication = {
      candidateId: candidate.id,
      campaignId: campaign.id,
      candidate: candidate,
      campaign: campaign
    };

  spyOn(httpClient, 'post').and.callFake((url: string) => {
    expect(url).toBe(ApiUrl.urlJobApplications);
    return of(jobApplication);
  });

  jobApplicationService.createJobApplication(jobApplication.candidateId, jobApplication.campaignId)
    .subscribe((result: JobApplication) =>
      expect(result).toEqual(jobApplication));
});

fit('should return list of jobapplications', () => {
  spyOn(httpClient, 'get').and.callFake((url: string) => {
    expect(url).toBe(ApiUrl.urlJobApplications);
    return of(createFakeJobApplications());
  });

  jobApplicationService.getJobApplications()
  .subscribe((result: JobApplication[]) => 
  expect(result.length).toEqual(2));
});

fit('should return a single jobapplication', () => {
  spyOn(httpClient, 'get').and.callFake((url: string) => {
    expect(url).toBe(`${ApiUrl.urlJobApplications}1`);
    return of(createFakeJobApplication());
  });

  jobApplicationService.getJobApplicationById('1')
  .subscribe((result: JobApplication) => 
  expect(result.campaign.name).toEqual('User'));
})
});

function createFakeJobApplications(): JobApplication[]{
  let campaign1: Campaign = 
  {
    id: '1',
    name: 'User',
    client: 'Client',
    startDate: new Date(),
    classStartDate: new Date()
  }

  let campaign2: Campaign = 
  {
    id: '2',
    name: 'Javacademy',
    client: 'Mixed',
    startDate: new Date(),
    classStartDate: new Date()
  }
  
  let candidate: Candidate = 
  {
    id: '1',
          firstName: 'UserFN1',
          lastName: 'UserLN1',
          email: 'User@email.one',
          phoneNumber: '0470000000',
          gitHubUserName: 'username1',
          linkedIn: 'username1',
          comment: 'comment1'
  }

  return [
    {
      id: '1',
      campaign: campaign1,
      campaignId: campaign1.id,
      candidate: candidate,
      candidateId: candidate.id
    },
    {
      id:'2',
      campaign: campaign2,
      campaignId: campaign2.id,
      candidate: candidate,
      candidateId: candidate.id
    }
  ]
}

function createFakeJobApplication(): JobApplication
{
  let campaign: Campaign = 
  {
    id: '1',
    name: 'User',
    client: 'Client',
    startDate: new Date(),
    classStartDate: new Date()
  };

  let candidate: Candidate = 
  {
    id: '1',
          firstName: 'UserFN1',
          lastName: 'UserLN1',
          email: 'User@email.one',
          phoneNumber: '0470000000',
          gitHubUserName: 'username1',
          linkedIn: 'username1',
          comment: 'comment1'
  };

  let jobApplication: JobApplication =
  {
    id: '1',
      campaign: campaign,
      campaignId: campaign.id,
      candidate: candidate,
      candidateId: candidate.id
  };

  return jobApplication;
}
