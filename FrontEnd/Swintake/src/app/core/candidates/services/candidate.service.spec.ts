import { CandidateService } from './candidate.service';
import { HttpClient } from '@angular/common/http';
import { Candidate } from '../classes/candidate';
import { of } from 'rxjs'
import { ApiUrl } from '../../CommonUrl/CommonUrl';

describe('CandidateService', () => {
  let httpClient: HttpClient;
  let candidateService: CandidateService;

  beforeEach(() => 
  {
    httpClient = ({ get: null, post: null } as unknown) as HttpClient;
    candidateService = new CandidateService(httpClient);
  });

  fit('should return new candidate', () => {

    let candidate: Candidate = {
      firstName: 'Peter',
      lastName: 'Parker',
      email: 'totallynotspiderman@gmail.com',
      phoneNumber: '0470000000',
      gitHubUserName: 'noYOUarespiderman',
      linkedIn: 'pp',
      comment: 'great candidate'
    };
    spyOn(httpClient, 'post').and.callFake((url: string) => {
      expect(url).toBe(ApiUrl.urlCandidates);
      return of(candidate);
    });

    candidateService.addCandidate(candidate)
      .subscribe((result: Candidate) =>
        expect(result).toEqual(candidate));
  });
  
  fit('should return list of candidates', () => 
  {
    spyOn(httpClient, 'get').and.callFake((url: string) => {
      expect(url).toBe(ApiUrl.urlCandidates);
      return of(createFakeCandidates());
    });

    candidateService.getCandidates()
    .subscribe((result: Candidate[]) =>
    expect(result.length).toEqual(2));
  });

  fit('should return a single candidate', () => {
    spyOn(httpClient, 'get').and.callFake((url: string) => {
      expect(url).toBe(`${ApiUrl.urlCandidates}1`);
      return of(createFakeCandidate());
    });

    candidateService.getCandidateById('1')
    .subscribe((result: Candidate) =>
    expect(result.firstName).toEqual('UserFN1'));
  })

});

  function createFakeCandidates(): Candidate[] 
  {
    return [
      {
          id: '1',
          firstName: 'UserFN1',
          lastName: 'UserLN1',
          email: 'User@email.one',
          phoneNumber: '0470000000',
          gitHubUserName: 'username1',
          linkedIn: 'username1',
          comment: 'comment1'
      },
      {
        id: '2',
        firstName: 'UserFN2',
        lastName: 'UserLN2',
        email: 'User@email.two',
        phoneNumber: '0470000000',
        gitHubUserName: 'username2',
        linkedIn: 'username2',
        comment: 'comment2'
      }
    ]
}

function createFakeCandidate(): Candidate{
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
  return candidate;
}